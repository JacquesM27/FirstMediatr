using MediatR;

namespace FirstMediatr.Functions.Command.SendMarketingNotification
{
    public class SendMarketingNotificationCommandHandler : IRequestHandler<SendMarketingNotificationCommand>
    {
        public Task Handle(SendMarketingNotificationCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Hey marketers! This book is updated! {request.Title}");
            return Task.CompletedTask;
        }
    }
}
