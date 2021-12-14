using Bookker.Data.Services;
using Bookker.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("get-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBook(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBook(id);
            return Ok();
        }
    }
}
