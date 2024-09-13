using Tree.Domain.Models;
using Tree.Persistence.Models;

namespace Tree.Persistence.Interfaces;
public interface IJournalRepository : IBaseRepository<Record> {

    Task<PaginatedResult<Record>> GetRecordsAsync(int skip, int top, DateTime? from = null, DateTime? to = null, string? search = null, CancellationToken  cancellation = default);
}
