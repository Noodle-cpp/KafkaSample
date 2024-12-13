using Application.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

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
        
        /// <summary>
        /// gets books
        /// </summary>
        /// <returns>list of books</returns>
        // GET: <BooksController>
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok();
        }
    }
}
