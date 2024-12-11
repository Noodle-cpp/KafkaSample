using Domain.Entities;

namespace Application.Abstractions.Interfaces;

public interface IBookService
{
    public Task<IEnumerable<Book>> GetAllBooksAsync();
}