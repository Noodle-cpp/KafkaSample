using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
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
