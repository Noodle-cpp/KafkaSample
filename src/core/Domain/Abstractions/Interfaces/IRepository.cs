namespace Persistence.Abstractions.Interfaces;

public interface IRepository<TEntity>
{
    public Task<TEntity?> GetAsync(ISpecification<TEntity> specification);
    public Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification);
}