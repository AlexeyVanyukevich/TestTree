using FluentValidation;

namespace Tree.Application.Nodes.Commands.RenameNode;
internal class RenameNodeCommandValidator : AbstractValidator<RenameNodeCommand> {

    public RenameNodeCommandValidator() {
        RuleFor(c => c.Id)
        .NotEmpty()
        .WithMessage($"The {nameof(RenameNodeCommand.Id)} field is required");

        RuleFor(c => c.Name)
        .NotEmpty()
        .WithMessage($"The {nameof(RenameNodeCommand.Name)} field is required");

    }
}
