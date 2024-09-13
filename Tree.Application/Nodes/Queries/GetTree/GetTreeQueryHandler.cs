

using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;
using Tree.Application.Nodes.Models;

namespace Tree.Application.Nodes.Queries.GetTree;
internal class GetTreeQueryHandler : IQueryHandler<GetTreeQuery, NodeResponse?> {
    
    private readonly IUnitOfWork _unitOfWork;
    public GetTreeQueryHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<NodeResponse?> Handle(GetTreeQuery request, CancellationToken cancellationToken) {
        var node = await _unitOfWork.Nodes.ToTreeAsync(request.Name, cancellationToken);

        if (node is null) {
            return null;
        }

        return new NodeResponse(node);
    }
}
