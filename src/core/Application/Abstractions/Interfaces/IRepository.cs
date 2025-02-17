namespace Application.Abstractions.Interfaces;

public interface IRepository<TModel>
{
    public Task<TModel?> GetAsync(ISpecification<TModel> specification);
    public Task<IEnumerable<TModel>> GetListAsync(ISpecification<TModel> specification);
}