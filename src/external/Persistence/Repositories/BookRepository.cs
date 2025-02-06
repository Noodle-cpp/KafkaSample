using Domain.Abstractions.Interfaces;
using Domain.Models;
using LinqToDB;

namespace Persistence.Repositories;

public class BookRepository : IBookRepositiry
{
    private readonly TestDbdb _testDb;

    public BookRepository(TestDbdb testDb)
    {
        _testDb = testDb;
    }
    
    public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
    {
        var books =  await _testDb.Books
            .Join(_testDb.Authors, book => book.AuthorId, author => author.Id, (book, author) =>
                new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorId = author.Id,
                    Author = author
                }).ToListAsync().ConfigureAwait(false);
            
        return books.Select(model => new BookModel
        {
            Id = model.Id,
            Title = model.Title,
            AuthorId = model.AuthorId,
            Author = new AuthorModel() 
        }); 
    }

    public Task<BookModel> GetBookByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<BookModel> CreateBookAsync(BookModel book)
    {
        throw new NotImplementedException();
    }
}