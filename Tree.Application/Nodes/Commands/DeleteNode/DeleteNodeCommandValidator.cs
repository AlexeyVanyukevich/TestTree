using FluentValidation;

using Tree.Application.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.DeleteNode;
internal class DeleteNodeCommandValidator : AbstractValidator<DeleteNodeCommand> {

    public DeleteNodeCommandValidator(IUnitOfWork unitOfWork) {
        RuleFor(c => c.Id)
        .NotEmpty()
        .WithMessage($"The {nameof(DeleteNodeCommand.Id)} field is required");

        RuleFor(c => c)
            .CustomAsync(async (command, context, cancellationToken) => {
                var node = await unitOfWork.Nodes.Configure(new Persistence.Interfaces.NodesRepositoryConfiguration {
                    IncludeParent = true,
                    IncludeParentChildren = true,
                    IncludeChildren = true
                }).GetByIdAsync(command.Id, cancellationToken: cancellationToken);

                if (node is null) {
                    context.AddFailure($"Node with {nameof(Node.Id)} = {command.Id} was not found");
                    return;
                }
                bool parentHashChildren = node.Parent?.Children.Any(c => c.Id != node.Id) ?? false;

                if (node.Children.Any() || parentHashChildren) {
                    context.AddFailure("You have to delete all children nodes first");
                }
            })
            .When(x => x.Id != Guid.Empty);
    }
}
