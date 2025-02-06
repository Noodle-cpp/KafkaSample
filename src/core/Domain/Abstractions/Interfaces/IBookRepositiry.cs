using Domain.Models;

namespace Domain.Abstractions.Interfaces;

public interface IBookRepositiry
{
    public Task<IEnumerable<BookModel>> GetAllBooksAsync();
    public Task<BookModel> GetBookByIdAsync(string id);
    public Task<BookModel> CreateBookAsync(BookModel book);
}