using FluentValidation;

using Tree.Application.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.RenameNode;
internal class RenameNodeCommandValidator : AbstractValidator<RenameNodeCommand> {

    public RenameNodeCommandValidator(IUnitOfWork unitOfWork) {
        RuleFor(c => c.Id)
        .NotEmpty()
        .WithMessage($"The {nameof(RenameNodeCommand.Id)} field is required");

        RuleFor(c => c.Name)
        .NotEmpty()
        .WithMessage($"The {nameof(RenameNodeCommand.Name)} field is required");

    }
}
