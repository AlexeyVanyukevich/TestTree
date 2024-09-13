using System.Net;

using Tree.API.Models;
using Tree.Application.Interfaces;

namespace Tree.API.MIddlewares;

internal sealed class ExceptionMiddleware {
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICorrelationIdGenerator correlationIdGenerator) {
        try {
            await _next(context);
        } catch (Exception ex) {
            var error = new ErrorResponse(ex, correlationIdGenerator.Get());

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(error);

        }
    }
}
