using Application.Abstractions.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class BookService : IBookService
{
    public Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }
}