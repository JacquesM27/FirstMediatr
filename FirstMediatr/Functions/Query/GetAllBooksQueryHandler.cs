using FirstMediatr.DummyData;
using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Query
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = request.OrderOption switch
            {
                Enum.OrderByBookOptions.None => StaticData.Books,
                Enum.OrderByBookOptions.Title => StaticData.Books.OrderBy(t => t.Title).ToList(),
                Enum.OrderByBookOptions.Author => StaticData.Books.OrderBy(t => t.Author).ToList(),
                Enum.OrderByBookOptions.Date => StaticData.Books.OrderBy(t => t.Date).ToList(),
                _ => StaticData.Books,
            };
            return Task.FromResult(books);
        }
    }
}
