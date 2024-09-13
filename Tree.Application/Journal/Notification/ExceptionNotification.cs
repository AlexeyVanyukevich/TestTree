using Tree.Application.Messaging.Interfaces;

namespace Tree.Application.Journal.Notification;
public class ExceptionNotification : INotification {
    public string EventId { get; init; }
    public Exception Exception { get; init; }
}
