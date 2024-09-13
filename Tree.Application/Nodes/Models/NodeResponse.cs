using Tree.Domain.Models;

namespace Tree.Application.Nodes.Models;
public class NodeResponse {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<NodeResponse> Children { get; set; }

    public NodeResponse(Node node) {
        Id = node.Id; 
        Name = node.Name;
        Children = new List<NodeResponse>();
        if (node.Children is not null) {
            foreach (var child in node.Children) {
                Children.Add(new NodeResponse(child));
            }
        }
    }
}
