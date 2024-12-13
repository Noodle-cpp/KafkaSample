using Application.Abstractions.Interfaces;
using Domain.Abstractions.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IKafkaProducer _producer;
    
    public BookService(IKafkaProducer producer, IKafkaConsumer consumer)
    {
        _producer = producer;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return new List<Book>();
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