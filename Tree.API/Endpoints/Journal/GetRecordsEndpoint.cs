using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Tree.API.Constants;
using Tree.API.Endpoints.Journal.Models;
using Tree.Application.Journal.Models;
using Tree.Application.Journal.Queries.GetRecordsQuery;
using Tree.Persistence.Models;

namespace Tree.API.Endpoints.Journal;

public class GetRecordsEndpoint : BaseEndpoint {
    public GetRecordsEndpoint() : base(EndpointsNames.Journal) {
    }

    protected override IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app) {
        return app.MapPost(string.Empty, HandleAsync);
    }

    private async Task<Ok<PaginatedResult<RecordResponse>>> HandleAsync(ISender sender, [FromQuery] int skip = 0, [FromQuery] int top = 5, [FromBody] GetRecordsRequest? request = null, CancellationToken cancellationToken = default) {
        var query = new GetRecordsQuery {
            Skip = skip,
            From = request?.From,
            Search = request?.Search,
            To = request?.To,
            Top = top
        };

        var records = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(records);
    }
}
