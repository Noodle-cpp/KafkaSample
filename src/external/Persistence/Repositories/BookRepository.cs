using Domain.Abstractions.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories;

public class BookRepository : IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}