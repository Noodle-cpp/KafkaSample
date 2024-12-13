using Domain.Entities;
using LinqToDB;
using LinqToDB.Data;

namespace Persistence;

public class TestDbContext : DataConnection
{
    public TestDbContext(DataOptions<TestDbContext> options) : base(options.Options)
    {

    }
    
    public ITable<Book> Books => this.GetTable<Book>();
    public ITable<Author> Authors => this.GetTable<Author>();
}