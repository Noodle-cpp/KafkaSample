using LinqToDB;
using LinqToDB.Data;

namespace Persistence;

public class TestDbContext : DataConnection
{
    public TestDbContext(DataOptions<TestDbContext> options) : base(options.Options)
    {

    }
}