using Domain.Abstractions.Interfaces;
using Domain.Entities;
using LinqToDB;
using LinqToDB.Tools;

namespace Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly TestDbContext _context;

    public BookRepository(TestDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync().ConfigureAwait(false);
    }

    public Task CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}