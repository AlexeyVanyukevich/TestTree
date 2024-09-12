using MediatR;

namespace Tree.Application.Messaging.Interfaces;
internal interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> {
}
