using Tree.Domain.Models;

namespace Tree.Application.Nodes.Models;
public class NodeResponse {
    private readonly Lazy<Guid> _id;
    public Guid Id => _id.Value;
    private readonly Lazy<string> _name;

    public string Name => _name.Value;
    private readonly Lazy<List<NodeResponse>> _children;
    public List<NodeResponse> Children => _children.Value;

    public NodeResponse(Node node) {
        _id = new Lazy<Guid>(() => node.Id);
        _name = new Lazy<string>(() => node.Name);
        _children = new Lazy<List<NodeResponse>>(() => {
            var children = new List<NodeResponse>();
            if (node.Children is not null) {
                foreach (var child in node.Children) {
                    children.Add(new NodeResponse(child));
                }
            }
            return children;
        });
    }
}
