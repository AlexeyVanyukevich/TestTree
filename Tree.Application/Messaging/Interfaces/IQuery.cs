using MediatR;

namespace Tree.Application.Messaging.Interfaces;
public interface IQuery<TResponse> : IRequest<TResponse> {
}
