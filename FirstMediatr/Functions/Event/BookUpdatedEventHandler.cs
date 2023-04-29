using FirstMediatr.Functions.Command.SendMarketingNotification;
using FirstMediatr.Functions.Command.SendNewsletterMail;
using MediatR;

namespace FirstMediatr.Functions.Event
{
    public class BookUpdatedEventHandler : INotificationHandler<BookUpdatedEvent>
    {
        private readonly IMediator _mediator;
        public BookUpdatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Handle(BookUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new SendMarketingNotificationCommand(notification.Book.Title), cancellationToken);
            await _mediator.Send(new SendNewsletterMailCommand(notification.Book), cancellationToken);
        }
    }
}
