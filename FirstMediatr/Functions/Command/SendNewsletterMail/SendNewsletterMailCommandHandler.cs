using MediatR;

namespace FirstMediatr.Functions.Command.SendNewsletterMail
{
    public class SendNewsletterMailCommandHandler : IRequestHandler<SendNewsletterMailCommand>
    {
        public Task Handle(SendNewsletterMailCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"To all people who are subscribed newsletter: Here is updated book: {request.Book.Title}");
            return Task.CompletedTask;
        }
    }
}
