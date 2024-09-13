using Tree.Domain.Models;
using Tree.Persistence.Interfaces;

namespace Tree.Persistence.Repositories;
internal class JournalRepository : BaseRepository<Record>, IJournalRepository {

    public JournalRepository(ApplicationDbContext context) : base(context) { }
}
