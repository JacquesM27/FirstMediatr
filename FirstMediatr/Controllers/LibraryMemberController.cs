using FirstMediatr.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryMemberController : ControllerBase
    {
        private readonly ILogger<LibraryMemberController> _logger;

        public LibraryMemberController(ILogger<LibraryMemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public string GetMember(int id)
        {
            throw new NotImplementedException("Not implemented Get of Library Member Controller!");
        }

        [HttpPost]
        public IActionResult PostMember(LibraryMember libraryMember)
        {
            _logger.LogInformation("PostMember method");
            //if (!ModelState.IsValid)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            //}
            return StatusCode(StatusCodes.Status200OK, "valid model");
        }
    }
}
