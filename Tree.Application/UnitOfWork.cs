using Microsoft.Extensions.DependencyInjection;

using Tree.Application.Interfaces;
using Tree.Persistence;
using Tree.Persistence.Interfaces;

namespace Tree.Application;

public sealed class UnitOfWork : IUnitOfWork {
    private readonly Lazy<INodesRepository> _nodesRepository;
    private readonly ApplicationDbContext _context;
    public INodesRepository Nodes => _nodesRepository.Value;

    public UnitOfWork(IServiceProvider serviceProvider, ApplicationDbContext context) {
        _nodesRepository = new Lazy<INodesRepository>(serviceProvider.GetRequiredService<INodesRepository>);
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
