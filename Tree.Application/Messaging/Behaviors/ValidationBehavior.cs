using FluentValidation;

using MediatR;

using Tree.Application.Exceptions;


namespace Tree.Application.Messaging.Behaviors;
internal class ValidationBehavior<TRequest, TResponse>
    : Interfaces.IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        if (!_validators.Any()) {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context)));


        var errors = validationResults
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validaitonResult => validaitonResult.Errors)
            .ToArray();

        if (errors.Any()) {
            throw new SecureException(errors);
        }

        var response = await next();

        return response;
    }
}
