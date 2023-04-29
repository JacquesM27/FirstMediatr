using MediatR;
using System.Diagnostics;

namespace FirstMediatr.Functions.Notification
{
    public class AddBookNotificationDebugHandler : INotificationHandler<AddBookNotification>
    {
        public Task Handle(AddBookNotification notification, CancellationToken cancellationToken)
        {
            Debugger.Log(1, "info", notification.Title);
            return Task.CompletedTask;
        }
    }
}
