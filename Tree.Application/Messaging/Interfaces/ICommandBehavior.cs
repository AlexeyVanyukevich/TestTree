namespace Tree.Application.Messaging.Interfaces;
internal interface ICommandBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : ICommandBase {
}
