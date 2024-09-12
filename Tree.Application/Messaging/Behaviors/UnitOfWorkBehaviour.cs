using MediatR;

using System.Transactions;

using Tree.Application.Interfaces;
using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Messaging.Behaviors;
internal sealed class UnitOfWorkBehaviour<TRequest, TResponse>
    : ICommandBehavior<TRequest, TResponse>
    where TRequest : notnull, ICommand {

    private readonly IUnitOfWork _unitOfWork;
    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var response = await next();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        transactionScope.Complete();

        return response;
    }
}
