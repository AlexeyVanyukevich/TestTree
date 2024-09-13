namespace Tree.Application.Messaging.Interfaces;
internal interface INotificationHandler<TNotificaiton>
    : MediatR.INotificationHandler<TNotificaiton>
    where TNotificaiton : INotification {
}
