using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Nodes.Commands.RenameNode;
public sealed class RenameNodeCommand : ICommand
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}
