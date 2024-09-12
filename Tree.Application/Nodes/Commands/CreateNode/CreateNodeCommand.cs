using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Nodes.Commands.CreateNode;
public sealed class CreateNodeCommand : ICommand
{
    public Guid? ParentNodeId { get; init; }
    public string Name { get; init; }
    public bool AsChild { get; init; }
}
