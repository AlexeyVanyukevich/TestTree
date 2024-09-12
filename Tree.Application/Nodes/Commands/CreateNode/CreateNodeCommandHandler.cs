using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.CreateNode;
internal class CreateNodeCommandHandler : ICommandHandler<CreateNodeCommand> {

    private readonly IUnitOfWork _unitOfWork;
    public CreateNodeCommandHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public Task Handle(CreateNodeCommand request, CancellationToken cancellationToken) {
        var node = new Node {
            Name = request.Name,
            ParentId = request.ParentNodeId
        };

        _unitOfWork.Nodes.Add(node);

        return Task.CompletedTask;
    }
}
