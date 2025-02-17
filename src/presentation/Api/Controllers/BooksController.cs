using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: <BooksController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(string id)
        {
            var book = await _bookService.GetBookByIdAsync(id).ConfigureAwait(false);
            return Ok(book);
        }

        // GET: <BooksController>
        [HttpGet()]
        public async Task<IActionResult> GetBooksListAsync()
        {
            var books = await _bookService.GetBooksAsync().ConfigureAwait(false);
            return Ok(books);
        }
    }
}
