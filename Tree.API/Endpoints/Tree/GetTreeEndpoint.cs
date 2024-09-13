
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

using Tree.API.Constants;
using Tree.Application.Nodes.Commands.CreateNode;
using Tree.Application.Nodes.Models;
using Tree.Application.Nodes.Queries.GetTree;

namespace Tree.API.Endpoints.Tree;

public class GetTreeEndpoint : BaseEndpoint {
    public GetTreeEndpoint() : base(EndpointsNames.TreeGroup) {
    }

    protected override IEndpointConventionBuilder MapEndpointInternal(IEndpointRouteBuilder app) {
        return app.MapGet("{name}", HandleAsync);
    }

    private async Task<Results<Ok<NodeResponse>, NotFound>> HandleAsync(string name, ISender sender, CancellationToken cancellationToken = default) {
        var query = new GetTreeQuery {
            Name = name
        };

        var tree = await sender.Send(query, cancellationToken);

        if (tree is null) {
            var command = new CreateNodeCommand {
                Name = name
            };

            var node = await sender.Send(command, cancellationToken);

            return TypedResults.Ok(node);
        }

        return TypedResults.Ok(tree);
    }
}
