using MediatR;

namespace Tree.Application.Messaging.Interfaces;
internal interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand {
}

internal interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> {
}
