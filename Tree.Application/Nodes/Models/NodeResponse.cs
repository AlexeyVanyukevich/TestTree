using Tree.Application.Models;
using Tree.Domain.Models;

namespace Tree.Application.Nodes.Models;
public class NodeResponse : BaseResponse<Node> {
    public string Name { get; }
    public List<NodeResponse> Children { get; }

    public NodeResponse(Node node) : base(node) {
        Name = node.Name;
        Children = new List<NodeResponse>();

        if (node.Children is not null) {
            foreach (var child in node.Children) {
                Children.Add(new NodeResponse(child));
            }
        }
    }
}
