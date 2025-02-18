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
        [HttpGet]
        public async Task<IActionResult> GetBooksListAsync([FromQuery]int page, [FromQuery]int countOnPage)
        {
            if (page == null || page <= 0)
                return BadRequest("Page must be equal to or greater than 1");
            if (countOnPage == null || (countOnPage <= 0 || countOnPage > 100))
                return BadRequest("countOnPage must be equal to or greater than 1 and less then 100");

            var books = await _bookService.GetBooksAsync(page, countOnPage).ConfigureAwait(false);
            return Ok(books);
        }
    }
}
