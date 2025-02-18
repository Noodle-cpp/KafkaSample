using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Models;

namespace Application.Services;

//TODO: Перенести интерфейс
public interface IBookService
{
    public Task<BookModel?> GetBookByIdAsync(string id);
    public Task<IEnumerable<BookModel>> GetBooksAsync(int page, int countOnPage);
}

public class BookService : IBookService
{
    private readonly IRepository<BookModel> _repository;
    private readonly ISpecification<BookModel> _specification;
    
    public BookService(IRepository<BookModel> repository, ISpecification<BookModel> specification)
    {
        _repository = repository;
        _specification = specification;
    }

    public async Task<BookModel?> GetBookByIdAsync(string id)
    {
        _specification.AddWhere(x => x.Id == id);
        _specification.AddLoadWith(x => x.Author);
        
        var book = await _repository.GetAsync(_specification).ConfigureAwait(false);
        return book;
    }

    public async Task<IEnumerable<BookModel>> GetBooksAsync(int page, int countOnPage)
    {
        _specification.AddLoadWith(x => x.Author);
        _specification.AddOrderBy(x => x.Title);
        _specification.Page = page;
        _specification.CountOnPage = countOnPage;
        
        var book = await _repository.GetListAsync(_specification).ConfigureAwait(false);
        return book;
    }
}