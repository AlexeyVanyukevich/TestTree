using Tree.Application.Exceptions;
using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.RenameNode;
internal class RenameNodeCommandHandler : ICommandHandler<RenameNodeCommand> {

    private readonly IUnitOfWork _unitOfWork;
    public RenameNodeCommandHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(RenameNodeCommand request, CancellationToken cancellationToken) {

        var node = await _unitOfWork.Nodes.Configure(new Persistence.Interfaces.NodesRepositoryConfiguration {
            IncludeParent = true,
            IncludeParentChildren = true
        }).GetByIdAsync(request.Id, cancellationToken: cancellationToken);

        if (node is null) {
            throw new SecureException($"Node with {nameof(Node.Id)} = {request.Id} was not found");
        }


        var nameExists = node.Parent is null
            ? await _unitOfWork.Nodes.RootExistsAsync(request.Name, cancellationToken)
            : node.Parent.Children.Any(n => n.Name == request.Name && n.Id != node.Id);

        if (nameExists) {
            var exceptionMessage = node.Parent is null
                ? "Duplicated name"
                : $"Node with {nameof(Node.Id)} = {request.Id} was not found";

            throw new SecureException(exceptionMessage);
        }

        node.Name = request.Name;


        _unitOfWork.Nodes.Update(node);
    }
}
