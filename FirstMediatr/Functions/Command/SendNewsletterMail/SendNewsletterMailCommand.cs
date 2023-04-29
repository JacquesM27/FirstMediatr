using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Command.SendNewsletterMail
{
    public class SendNewsletterMailCommand : IRequest
    {
        public Book Book { get; }
        public SendNewsletterMailCommand(Book book)
        {
            Book = book;
        }
    }
}
