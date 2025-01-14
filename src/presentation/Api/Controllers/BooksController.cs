using Api.ViewModels.Responses;
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
            var books = await _bookService.GetAllBooksAsync().ConfigureAwait(false);
            var response = books.Select(x => new BookResponse()
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                Title = x.Title,
                Author = new AuthorResponse()
                {
                    Id = x.AuthorId,
                    DateOfBirth = x.Author.DateOfBirth,
                    FIO = x.Author.FIO
                },
            });
            return Ok(response);
        }
    }
}
