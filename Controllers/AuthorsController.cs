using Bookker.Data.Services;
using Bookker.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-author-books/{id}")]
        public IActionResult GetAuthorBooks(int id)
        {
            var response = _authorsService.GetAuthorBooks(id);
            return Ok(response);
        }
    }
}
