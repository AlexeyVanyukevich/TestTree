using Tree.Application.Journal.Models;
using Tree.Application.Messaging.Interfaces;
using Tree.Persistence.Models;

namespace Tree.Application.Journal.Queries.GetRecordsQuery;
public sealed class GetRecordsQuery : IQuery<PaginatedResult<RecordResponse>> {
    public int Skip { get; init; }
    public int Top { get; init; }
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
    public string? Search { get; init; }
}
