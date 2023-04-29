using FirstMediatr.DummyData;
using FirstMediatr.Functions.Event;
using FirstMediatr.Model;
using MediatR;

namespace FirstMediatr.Functions.Command
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IMediator _mediator;
        public UpdateBookCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
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
            int index = StaticData.Books.FindIndex(x => x.Id == request.Id);
            if(index == -1)
            {
                StaticData.Books[index] = book;
            }
            await _mediator.Publish(new BookUpdatedEvent(book), cancellationToken);
            //return Task.CompletedTask;
        }
    }
}
