using MediatR;

namespace Cqrs_MediatR_Implementation.Notifications
{
    public class StatusNotification : INotification
    {
        public StatusNotification(string location)
        {
            Location = location;
        }

        public string Location { get; }
    }
}
