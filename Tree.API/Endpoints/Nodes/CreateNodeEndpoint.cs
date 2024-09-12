using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;

using Tree.API.Constants;
using Tree.API.Endpoints.Nodes.Models;
using Tree.Application.Nodes.Commands.CreateNode;

namespace Tree.API.Endpoints.Nodes;

public class CreateNodeEndpoint : BaseEndpoint {
    public CreateNodeEndpoint() : base(EndpointsNames.NodesGroup) {
    }

    protected override void MapEndpointInternal(IEndpointRouteBuilder app) {
        app.MapPost(string.Empty, HandleAsync);
    }

    private async Task<Results<Ok, BadRequest>> HandleAsync(CreateNodeRequest request, ISender sender, CancellationToken cancellationToken = default) {        
        var command = new CreateNodeCommand {
            Name = request.Name,
            ParentNodeId = request.ParentNodeId,
            AsChild = true
        };

        await sender.Send(command, cancellationToken);

        return TypedResults.Ok();
    }
}
