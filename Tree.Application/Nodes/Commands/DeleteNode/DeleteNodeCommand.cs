using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Nodes.Commands.DeleteNode;
public sealed class DeleteNodeCommand : ICommand
{
    public Guid Id { get; init; }
}
