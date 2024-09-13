using Tree.Application.Messaging.Interfaces;
using Tree.Application.Nodes.Models;

namespace Tree.Application.Nodes.Commands.CreateNode;
public sealed class CreateNodeCommand : ICommand<NodeResponse>
{
    public Guid? ParentNodeId { get; init; }
    public string Name { get; init; }
    public bool AsChild { get; init; }
}
