using Microsoft.Extensions.DependencyInjection;

using Tree.Application.Interfaces;
using Tree.Persistence;
using Tree.Persistence.Interfaces;

namespace Tree.Application;

public sealed class UnitOfWork : IUnitOfWork {
    private readonly ApplicationDbContext _context;

    private readonly Lazy<INodesRepository> _nodesRepository;
    public INodesRepository Nodes => _nodesRepository.Value;
    private readonly Lazy<IJournalRepository> _journalRepository;

    public IJournalRepository Journal => _journalRepository.Value;

    public UnitOfWork(IServiceProvider serviceProvider, ApplicationDbContext context) {
        _nodesRepository = new Lazy<INodesRepository>(serviceProvider.GetRequiredService<INodesRepository>);
        _journalRepository = new Lazy<IJournalRepository>(serviceProvider.GetRequiredService<IJournalRepository>);
        _context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
