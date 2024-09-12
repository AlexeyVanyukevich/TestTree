using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class NodesRepository
    : BaseRepository<Node>, INodesRepository {
    public NodesRepository(ApplicationDbContext context) : base(context) {}
}
