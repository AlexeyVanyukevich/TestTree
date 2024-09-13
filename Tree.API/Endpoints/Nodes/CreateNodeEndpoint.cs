using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;

using Tree.API.Constants;
using Tree.API.Endpoints.Nodes.Models;
using Tree.Application.Nodes.Commands.CreateNode;

namespace Tree.API.Endpoints.Nodes;

public class CreateNodeEndpoint : BaseEndpoint {
    public CreateNodeEndpoint() : base(EndpointsNames.NodesGroup) {
    }

    protected override IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app) {
        return app.MapPost("{parentId:guid}", HandleAsync);
    }

    private async Task<Ok> HandleAsync(Guid parentId, CreateNodeRequest request, ISender sender, CancellationToken cancellationToken = default) {        
        var command = new CreateNodeCommand {
            Name = request.Name,
            ParentNodeId = parentId,
            AsChild = true
        };

        await sender.Send(command, cancellationToken);

        return TypedResults.Ok();
    }
}
