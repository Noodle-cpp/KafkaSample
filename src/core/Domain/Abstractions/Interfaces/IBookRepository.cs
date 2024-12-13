using Domain.Entities;

namespace Domain.Abstractions.Interfaces;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooksAsync();
    public Task CreateBookAsync(Book book);
}