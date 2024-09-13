using Tree.Application.Messaging.Interfaces;
using Tree.Application.Nodes.Models;

namespace Tree.Application.Nodes.Queries.GetTree;
public class GetTreeQuery : IQuery<NodeResponse?>
{
    public string Name { get; init; }
}
