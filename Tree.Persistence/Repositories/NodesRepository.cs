using Microsoft.EntityFrameworkCore;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class NodesRepository
    : BaseRepository<Node>, INodesRepository {
    public NodesRepository(ApplicationDbContext context) : base(context) {}

    protected override IQueryable<Node> Query(bool tracking) {
        return base.Query(tracking)
            .Include(n => n.Children)
            .Include(n => n.Parent)
            .ThenInclude(p => p.Children);
    }
}
