using MediatR;

namespace FirstMediatr.Functions.Notification
{
    public class AddBookNotificationHandler : INotificationHandler<AddBookNotification>
    {
        public Task Handle(AddBookNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Title);
            return Task.CompletedTask;
        }
    }
}
