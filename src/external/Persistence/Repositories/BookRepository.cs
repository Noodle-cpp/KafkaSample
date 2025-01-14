using Domain.Abstractions.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Book
            .Join(_context.Author,
                book => book.AuthorId,
                author => author.Id,
                (book, author) => new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Author = author
                }
            )
            .ToListAsync().ConfigureAwait(false);
        // return await _context.Book.Include(x => x.Author)
        //                           .ToListAsync().ConfigureAwait(false);
    }

    public Task CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}