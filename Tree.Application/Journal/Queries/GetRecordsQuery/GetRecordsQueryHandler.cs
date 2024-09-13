using Tree.Application.Interfaces;
using Tree.Application.Journal.Models;
using Tree.Application.Messaging.Interfaces;
using Tree.Persistence.Models;

namespace Tree.Application.Journal.Queries.GetRecordsQuery;
internal sealed class GetRecordsQueryHandler : IQueryHandler<GetRecordsQuery, PaginatedResult<RecordResponse>> {
    private readonly IUnitOfWork _unitOfWork;
    public GetRecordsQueryHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task<PaginatedResult<RecordResponse>> Handle(GetRecordsQuery request, CancellationToken cancellationToken) {
        var records = await _unitOfWork.Journal.GetRecordsAsync(request.Skip, request.Top, request.From, request.To, request.Search, cancellationToken);

        return new PaginatedResult<RecordResponse> {
            Skip = request.Skip,
            Count = records.Count,
            Items = records.Items.Select(record => new RecordResponse(record)).ToList()
        };
    }
}
