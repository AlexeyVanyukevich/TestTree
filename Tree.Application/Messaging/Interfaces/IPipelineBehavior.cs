namespace Tree.Application.Messaging.Interfaces;
internal interface IPipelineBehavior<TRequest, TResponse> 
    : MediatR.IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull {
}
