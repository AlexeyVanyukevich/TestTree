using FluentValidation.Results;

namespace Tree.Application.Exceptions;
public sealed class SecureException : Exception {

    public SecureException(IEnumerable<ValidationFailure> validationFailures) {

    }
}
