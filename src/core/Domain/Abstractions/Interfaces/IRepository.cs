using LinqToDB;

namespace Domain.Abstractions.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> Entity { get; }
    
    ITable<T> Table { get; }
}