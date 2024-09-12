namespace Tree.Domain.Models;
public class Node : Base {
    public string Name { get; set; }

    public Guid? ParentId { get; set; }
    public Node Parent { get; set; }
    public ICollection<Node> Children { get; set; }

}
