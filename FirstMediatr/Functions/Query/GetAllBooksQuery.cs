using FirstMediatr.Enum;
using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Query
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
        public OrderByBookOptions OrderOption { get; set; }
    }
}
