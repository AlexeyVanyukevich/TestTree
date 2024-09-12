using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Nodes.Commands.DeleteNode;
internal class DeleteNodeCommandHandler : ICommandHandler<DeleteNodeCommand> {

    private readonly IUnitOfWork _unitOfWork;
    public DeleteNodeCommandHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public Task Handle(DeleteNodeCommand request, CancellationToken cancellationToken) {

        _unitOfWork.Nodes.Delete(request.Id);

        return Task.CompletedTask;
    }
}
