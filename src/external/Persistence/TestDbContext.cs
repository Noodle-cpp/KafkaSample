using Domain.Entities;
using LinqToDB;
using LinqToDB.Data;

namespace Persistence;

public class TestDbContext : DataConnection
{
    public TestDbContext(DataOptions<TestDbContext> options) : base(options.Options)
    {

    }
    
    public ITable<Book> Book => this.GetTable<Book>();
    public ITable<Author> Author => this.GetTable<Author>();
}