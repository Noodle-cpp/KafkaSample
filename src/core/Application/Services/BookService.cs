using Domain.Abstractions;
using Domain.Models;
using Persistence.Abstractions.Interfaces;

namespace Application.Services;

//TODO: Убрать
public interface IBookService
{
    public Task<BookModel?> GetBookByIdAsync(string id);
}

public class BookService
{
    private readonly IRepository<BookModel> _repository;

    public BookService(IRepository<BookModel> repository)
    {
        _repository = repository;
    }

    public async Task<BookModel?> GetBookByIdAsync(string id)
    {
        var spec = new BaseSpecification<BookModel>();
        spec.Where(b => b.Id.Equals(id));
        
        var book = await _repository.GetAsync(spec).ConfigureAwait(false);
        return book;
    }
}