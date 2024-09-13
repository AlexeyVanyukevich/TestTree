using Tree.Application.Exceptions;

namespace Tree.API.Models;

internal sealed class ErrorResponse {
    public string Type { get; }
    public string Id { get; }
    public ErrorResponseData Data { get; }
    public ErrorResponse(Exception exception, string id) {
        Type = exception is SecureException ? "Secure" : "Exception";
        Id = id;
        Data = new ErrorResponseData(exception, id);
    }
}

internal sealed class ErrorResponseData {
    public string Message { get; }

    public ErrorResponseData(Exception exception, string id) {
        Message = exception is SecureException ? exception.Message : $"Internal server error ID = {id}";
    }
}