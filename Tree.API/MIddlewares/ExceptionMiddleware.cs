using MediatR;

using System.Net;

using Tree.API.Models;
using Tree.Application.Interfaces;
using Tree.Application.Journal.Notification;

namespace Tree.API.MIddlewares;

internal sealed class ExceptionMiddleware {
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IPublisher publisher, ICorrelationIdGenerator correlationIdGenerator) {
        try {
            await _next(context);
        } catch (Exception ex) {
            var eventId = correlationIdGenerator.Get();
            var error = new ErrorResponse(ex, eventId);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(error);

            _ = publisher.Publish(new ExceptionNotification {
                EventId = eventId,
                Exception = ex
            });
        }
    }
}
