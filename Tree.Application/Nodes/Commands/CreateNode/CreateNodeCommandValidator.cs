using FluentValidation;

using Tree.Application.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.CreateNode;
internal class CreateNodeCommandValidator : AbstractValidator<CreateNodeCommand> {

    public CreateNodeCommandValidator(IUnitOfWork unitOfWork) {
        RuleFor(c => c.ParentNodeId)
        .NotEmpty()
        .WithMessage($"The {nameof(CreateNodeCommand.ParentNodeId)} field is required")
        .When(x => x.AsChild);

        RuleFor(c => c.Name)
        .NotEmpty()
        .WithMessage($"The {nameof(CreateNodeCommand.Name)} field is required");

        RuleFor(c => c)
            .CustomAsync(async (command, context, cancellationToken) => {
                var node = await unitOfWork.Nodes.GetByIdAsync(command.ParentNodeId!.Value, cancellationToken: cancellationToken);

                if (node is null) {
                    context.AddFailure($"Node with {nameof(Node.Id)} = {command.ParentNodeId} was not found");
                    return;
                }

                if (node.Children.Any(n => n.Name == command.Name)) {
                    context.AddFailure("Duplicate name");
                    return;
                }
            })
            .When(x => x.ParentNodeId.HasValue && x.ParentNodeId != Guid.Empty && !string.IsNullOrEmpty(x.Name));
    }
}
