using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Event
{
    public class BookUpdatedEvent : INotification
    {
        public Book Book { get; }
        public BookUpdatedEvent(Book book)
        {
            Book = book;
        }
    }
}
