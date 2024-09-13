using Tree.Application.Interfaces;
using Tree.Application.Journal.Notification;
using Tree.Application.Messaging.Interfaces;
using Tree.Domain.Models;

namespace Tree.Application.Journal.Handlers;
internal sealed class ExceptionNotificationHandler : INotificationHandler<ExceptionNotification> {
    private readonly IUnitOfWork _unitOfWork;

    public ExceptionNotificationHandler(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(ExceptionNotification notification, CancellationToken cancellationToken) {
        var record = new Record {
            EventId = notification.EventId,
            Text = notification.Exception.StackTrace ?? notification.Exception.Message
        };

        _unitOfWork.Journal.Add(record);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
