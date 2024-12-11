using Domain.Abstractions.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }
}