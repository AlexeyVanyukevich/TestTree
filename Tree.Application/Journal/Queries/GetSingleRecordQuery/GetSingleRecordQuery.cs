using Tree.Application.Journal.Models;
using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Journal.Queries.GetSingleRecordQuery;
public sealed class GetSingleRecordQuery : IQuery<RecordResponse> {
    public Guid Id { get; init; }
}
