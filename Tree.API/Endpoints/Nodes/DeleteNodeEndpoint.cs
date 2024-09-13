using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Tree.API.Constants;
using Tree.Application.Nodes.Commands.DeleteNode;

namespace Tree.API.Endpoints.Nodes;

public class DeleteNodeEndpoint : BaseEndpoint{

    public DeleteNodeEndpoint() : base(EndpointsNames.NodesGroup) {
    }

    protected override IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app) {
        return app.MapDelete("{id:guid}", HandleAsync);
    }

    private async Task<Results<Ok, BadRequest>> HandleAsync(Guid id, ISender sender, CancellationToken cancellationToken = default) {
        var command = new DeleteNodeCommand {
            Id = id
        };

        await sender.Send(command, cancellationToken);

        return TypedResults.Ok();
    }
}
