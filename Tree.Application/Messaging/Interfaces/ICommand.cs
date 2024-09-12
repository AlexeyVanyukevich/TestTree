using MediatR;

namespace Tree.Application.Messaging.Interfaces;
public interface ICommand : IRequest, ICommandBase {
}

public interface ICommand<TResponse> : IRequest<TResponse>, ICommandBase {

}

public interface ICommandBase { }

