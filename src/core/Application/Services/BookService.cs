using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Models;

namespace Application.Services;

//TODO: Перенести интерфейс
public interface IBookService
{
    public Task<BookModel?> GetBookByIdAsync(string id);
    public Task<IEnumerable<BookModel>> GetBooksAsync();
}

public class BookService : IBookService
{
    private readonly IRepository<BookModel> _repository;
    
    public BookService(IRepository<BookModel> repository)
    {
        _repository = repository;
    }

    public async Task<BookModel?> GetBookByIdAsync(string id)
    {
        var spec = new BaseSpecification<BookModel>();
        spec.Where(b => b.Id == id);
        spec.LoadWith(b => b.Author);
        
        var book = await _repository.GetAsync(spec).ConfigureAwait(false);
        return book;
    }

    public async Task<IEnumerable<BookModel>> GetBooksAsync()
    {
        var spec = new BaseSpecification<BookModel>();
        spec.OrderBy(b => b.Title);
        spec.LoadWith(b => b.Author);
        
        var book = await _repository.GetListAsync(spec).ConfigureAwait(false);
        return book;
    }
}