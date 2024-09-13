using FluentValidation.Results;

namespace Tree.Application.Exceptions;

public sealed class SecureException : Exception {

    public SecureException(string message) : base(message) { }
    public SecureException(string message, SecureException? innerException) : base(message, innerException) { }

    public static SecureException? FromValidationFailure(IEnumerable<ValidationFailure> validationFailures) {
        if (validationFailures.Any()) {
            return new SecureException(validationFailures.First().ErrorMessage, FromValidationFailure(validationFailures.Skip(1)));
        }

        return null;
    }
}
