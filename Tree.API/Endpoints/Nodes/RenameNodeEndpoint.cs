using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Tree.API.Constants;
using Tree.API.Endpoints.Nodes.Models;
using Tree.Application.Nodes.Commands.RenameNode;

namespace Tree.API.Endpoints.Nodes;

public class RenameNodeEndpoint : BaseEndpoint {
    public RenameNodeEndpoint() : base(EndpointsNames.NodesGroup) {
    }

    protected override void MapEndpointInternal(IEndpointRouteBuilder app) {
        app.MapPatch("{id:guid}", HandleAsync);
    }

    private async Task<Results<Ok, BadRequest>> HandleAsync(Guid id, RenameNodeRequest request, ISender sender, CancellationToken cancellationToken = default) {
        var command = new RenameNodeCommand {
            Name = request.Name,
            Id = id
        };

        await sender.Send(command, cancellationToken);

        return TypedResults.Ok();
    }
}
