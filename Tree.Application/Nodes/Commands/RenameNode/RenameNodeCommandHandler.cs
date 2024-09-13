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

        if (node.Parent is not null && node.Parent.Children.Any(n => n.Name == request.Name && n.Id != node.Id)) {
            throw new SecureException($"Node with {nameof(Node.Id)} = {request.Id} was not found");
        }

        node.Name = request.Name;


        _unitOfWork.Nodes.Update(node);
    }
}
