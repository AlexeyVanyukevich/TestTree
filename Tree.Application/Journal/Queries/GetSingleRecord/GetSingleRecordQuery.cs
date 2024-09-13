using Tree.Application.Journal.Models;
using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Journal.Queries.GetSingleRecord;
public class GetSingleRecordQuery : IQuery<RecordResponse> {
    public Guid Id { get; init; }
}
