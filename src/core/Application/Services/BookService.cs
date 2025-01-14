using Application.Abstractions.Interfaces;
using Domain.Abstractions.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IKafkaProducer _producer;
    private readonly IBookRepository _bookRepository;
    
    public BookService(IKafkaProducer producer, IKafkaConsumer consumer, IBookRepository bookRepository)
    {
        _producer = producer;
        _bookRepository = bookRepository;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _bookRepository.GetAllBooksAsync().ConfigureAwait(false);
    }

    public async Task CreateBookAsync(Book book)
    {
        var books = new Book[]
        {
            new Book()
            {
                Title = "title",
            },
            new Book()
            {
                Title = "title 2",
            },
        };
        
        _producer.SendMessage("test_topic", "key1", books);
    }
}