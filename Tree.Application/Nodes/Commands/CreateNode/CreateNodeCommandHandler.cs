using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;
using Tree.Application.Nodes.Models;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Commands.CreateNode;
internal class CreateNodeCommandHandler : ICommandHandler<CreateNodeCommand, NodeResponse>
{

    private readonly IUnitOfWork _unitOfWork;
    public CreateNodeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<NodeResponse> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
    {
        var node = new Node
        {
            Name = request.Name,
            ParentId = request.ParentNodeId
        };

        _unitOfWork.Nodes.Add(node);

        return Task.FromResult(new NodeResponse(node));
    }
}
