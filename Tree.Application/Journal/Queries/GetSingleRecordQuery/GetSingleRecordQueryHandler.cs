using Tree.Application.Interfaces;
using Tree.Application.Journal.Models;
using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Journal.Queries.GetSingleRecordQuery;
internal sealed class GetSingleRecordQueryHandler : IQueryHandler<GetSingleRecordQuery, RecordResponse> {
    private readonly IUnitOfWork _unitOfWork;

    public GetSingleRecordQueryHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task<RecordResponse> Handle(GetSingleRecordQuery request, CancellationToken cancellationToken) {
        var record = await _unitOfWork.Journal.GetByIdAsync(request.Id, cancellationToken: cancellationToken);

        if (record is null) {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        return new RecordResponse(record);
    }
}
