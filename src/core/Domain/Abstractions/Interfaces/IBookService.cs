using Domain.Models;

namespace Domain.Abstractions.Interfaces;

public interface IBookService
{
    public Task<BookModel?> GetBookByIdAsync(string id);
    public Task<IEnumerable<BookModel>> GetBooksAsync(int page, int countOnPage);
}