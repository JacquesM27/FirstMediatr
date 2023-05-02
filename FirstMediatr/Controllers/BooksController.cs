using FirstMediatr.Functions.Command;
using FirstMediatr.Functions.Notification;
using FirstMediatr.Functions.Query;
using FirstMediatr.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("books")]
        public async Task<List<Book>> GetAllBooks()
        {
            var request = new GetAllBooksQuery { OrderOption = Enum.OrderByBookOptions.Date };
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        [Route("addbook")]
        public async Task AddBook(string title)
        {
            await _mediator.Publish(new AddBookNotification { Title = title });
        }

        [HttpPut]
        public async Task UpdateBook(int id)
        {
            var updateCommand = new UpdateBookCommand
            {
                Author = "John",
                Title = "Hello world",
                Category = new Category { Id = 1, Name = "aaa"},
                CategoryId = 1,
                Date = DateTime.Now,
                Description = "First John's application!",
                Id = id,
                Rate = 99,
            };
            await _mediator.Send(updateCommand);
        }

        [HttpDelete]
        public async Task DeleteBook(int id)
        {
            throw new NotImplementedException("This method has not yet been implemented!");
        }

    }
}
