using MediatR;

namespace Cqrs_MediatR_Implementation.Notifications
{
    public class StatusNotificationHandler : INotificationHandler<StatusNotification>
    {
        public async Task Handle(StatusNotification notification, CancellationToken cancellationToken)
        {
            await Task.Delay(10000);
            Console.WriteLine(notification);
            Console.WriteLine($"The police service received a notificaiton about the accident");
            Console.WriteLine($"Police were dispatched to the location: {notification.Location}");
        }
    }
}
