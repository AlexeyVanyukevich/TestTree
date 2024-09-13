using Microsoft.EntityFrameworkCore;

using Npgsql;

using Tree.Domain.Models;
using Tree.Persistence.Constants;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class NodesRepository
    : BaseRepository<Node>, INodesRepository {
    public NodesRepository(ApplicationDbContext context) : base(context) {}
    private bool _includeParent;
    private bool _includeChildren;
    private bool _includeParentChildren;
    public INodesRepository Configure(NodesRepositoryConfiguration configuration) {
        _includeParent = configuration.IncludeParent;
        _includeChildren = configuration.IncludeChildren;
        _includeParent = configuration.IncludeParentChildren;

        return this;
    }

    protected override IQueryable<Node> Query(bool tracking) {
        var query = base.Query(tracking);

        if (_includeChildren) {
            query = query.Include(n =>  n.Children);
        }

        if (_includeParent) {
            var parentInlcudedQuery = query.Include(n => n.Parent);

            if (_includeParentChildren) {
                query = parentInlcudedQuery.ThenInclude(p => p.Children);
            } else {
                query = parentInlcudedQuery;
            }
        }

        return query;
    }

    public async Task<Node?> ToTreeAsync(string name, CancellationToken cancellationToken = default) {

        var nameParameterName = ":Name";
        var cteName = "RecursiveHierarchy";
        var sqlQuery = @$"
            WITH RECURSIVE {cteName} AS (
                SELECT 
                    ""{nameof(Node.Id)}"",
                    ""{nameof(Node.Name)}"",
                    ""{nameof(Node.ParentId)}""
                FROM ""{TablesNames.Nodes}""
                WHERE ""{nameof(Node.ParentId)}"" IS NULL AND ""{nameof(Node.Name)}"" = {nameParameterName}

                UNION ALL

                SELECT 
                    n.""{nameof(Node.Id)}"",
                    n.""{nameof(Node.Name)}"",
                    n.""{nameof(Node.ParentId)}""
                FROM ""{TablesNames.Nodes}"" n
                INNER JOIN {cteName} r ON n.""{nameof(Node.ParentId)}"" = r.""{nameof(Node.Id)}""
            )
            SELECT * FROM {cteName};

        ";

        var nameParameter = new NpgsqlParameter(nameParameterName, name);

        var nodes = await DbSet
            .FromSqlRaw(sqlQuery, nameParameter)
            .ToListAsync(cancellationToken);

        return BuildHierarchy(nodes).FirstOrDefault();
    }

    public List<Node> BuildHierarchy(List<Node> nodes) {
        var nodeDictionary = nodes.ToDictionary(n => n.Id);

        foreach (var node in nodes) {
            if (node.ParentId.HasValue && nodeDictionary.TryGetValue(node.ParentId.Value, out var parent)) {
                if (parent.Children is null) {
                    parent.Children = new List<Node>();
                }
                parent.Children.Add(node);
            }
        }

        return nodes.Where(n => !n.ParentId.HasValue).ToList();
    }

    public Task<bool> RootExistsAsync(string name, CancellationToken cancellationToken = default) {
        return AnyAsync(node => node.ParentId == null && node.Name == name, cancellationToken);
    }
}
