using Microsoft.EntityFrameworkCore;

using Tree.Domain.Models;
using Tree.Persistence.Interfaces;
using Tree.Persistence.Models;

namespace Tree.Persistence.Repositories;
internal class JournalRepository : BaseRepository<Record>, IJournalRepository {

    public JournalRepository(ApplicationDbContext context) : base(context) { }

    public async Task<PaginatedResult<Record>> GetRecordsAsync(int skip, int top, DateTime? from = null, DateTime? to = null, string? search = null, CancellationToken cancellation = default) {
        var query = DbSet.AsQueryable();

        if (from.HasValue) {
            query = query.Where(r => r.CreatedAt >= from.Value);
        }

        if (to.HasValue) {
            query = query.Where(r => r.CreatedAt <= to.Value);
        }

        if (!string.IsNullOrEmpty(search)) {
            query = query.Where(r => r.Text.Contains(search));
        }

        var count = await query.CountAsync();

        var records = await query
            .OrderByDescending(r => r.Id)
            .Skip(skip)
            .Take(top)
            .Select(record => new Record {
                EventId = record.EventId,
                Id = record.Id,
                CreatedAt = record.CreatedAt
            })
            .ToListAsync();

        return new PaginatedResult<Record> {
            Count = count,
            Items = records,
            Skip = skip
        };
    }
}
