﻿using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Tree.API.Constants;
using Tree.Application.Journal.Models;
using Tree.Application.Journal.Queries.GetSingleRecordQuery;

namespace Tree.API.Endpoints.Journal;

public class GetSingleEndpoint : BaseEndpoint {

    public GetSingleEndpoint() : base(EndpointsNames.Journal) {
    }

    protected override IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app) {
        return app.MapGet("{id:guid}", HandleAsync);
    }

    private async Task<Ok<RecordResponse>> HandleAsync(Guid id, ISender sender, CancellationToken cancellationToken = default) {
        var query = new GetSingleRecordQuery {
            Id = id
        };

        var record = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(record);
    }
}
