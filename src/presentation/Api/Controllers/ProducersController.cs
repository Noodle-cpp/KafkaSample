using Application.Abstractions.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IBookService _bookService;
        
        public ProducersController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync()
        {
            await _bookService.CreateBookAsync(new Book()).ConfigureAwait(false);
            return Ok();
        }
    }
}
