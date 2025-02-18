using Api.ViewModels.Responses;
using Application.Exceptions;
using Application.Services;
using AutoMapper;
using Domain.Abstractions.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: <BooksController>/{id}
        /// <summary>
        /// Получает информацию о книге по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор книги</param>
        /// <returns>Книгу</returns>
        /// <response code="200">Информация о книге получена</response>
        /// <response code="404">Информация о книге не найдена</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookAsync(string id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id).ConfigureAwait(false);
                return Ok(_mapper.Map<BookResponse>(book));
            }
            catch (BookNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: <BooksController>
        /// <summary>
        /// Получает список информации о книгах
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="countOnPage">Кол-во элементов на странице</param>
        /// <returns>Список книг</returns>
        /// <response code="200">Информация о книгах получена</response>
        /// <response code="400">Неверный запрос от пользователя</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooksListAsync([FromQuery]int? page, [FromQuery]int? countOnPage)
        {
            if (page is null or <= 0)
                return BadRequest("Номер страницы должен быть больше или равен 1");
            if (countOnPage is null or <= 0 or > 100)
                return BadRequest("Кол-во элементов на странице должно быть больше 0 и меньше 100");

            var books = await _bookService.GetBooksAsync((int)page, (int)countOnPage).ConfigureAwait(false);
            return Ok(_mapper.Map<IEnumerable<BookResponse>>(books));
        }
    }
}
