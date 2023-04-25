using FirstMediatr.DummyData;
using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Command
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        public Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Author = request.Author,
                Category = request.Category,
                CategoryId = request.CategoryId,
                Date = request.Date,
                Description = request.Description,
                Id = request.Id,
                Rate = request.Rate,
                Title = request.Title,
            };
            int index = StaticData.Books.FindIndex(x => x.Id== request.Id);
            if(index == -1)
            {
                StaticData.Books[index] = book;
            }
            return Task.CompletedTask;
        }
    }
}
