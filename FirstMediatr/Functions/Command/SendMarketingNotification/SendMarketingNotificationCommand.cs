using MediatR;

namespace FirstMediatr.Functions.Command.SendMarketingNotification
{
    public class SendMarketingNotificationCommand : IRequest
    {
        public string Title { get; }
        public SendMarketingNotificationCommand(string title)
        {
            Title = title;
        }
    }
}
