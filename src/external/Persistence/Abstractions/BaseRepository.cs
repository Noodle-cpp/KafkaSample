using Application.Abstractions;
using Application.Abstractions.Interfaces;
using AutoMapper;
using Domain.Models;
using LinqToDB;
using Persistence.Entity;
using Persistence.Extensions;

namespace Persistence.Abstractions;

public class BaseRepository<TModel, TEntity> : BaseSpecification<TModel>, IRepository<TModel>
    where TModel : class
    where TEntity : class
{
    private readonly IMapper _mapper;
    private readonly TestDbdb _testDb;

    public BaseRepository(TestDbdb testDb, IMapper mapper)
    {
        _mapper = mapper;
        _testDb = testDb;
    }

    public async Task<TModel?> GetAsync(ISpecification<TModel> specification)
    {
        var entitySpecification = _mapper.Map<BaseSpecification<TEntity>>(specification);

        var query = _testDb.GetTable<TEntity>().Specify(entitySpecification);
        
        var entity = await query.SingleOrDefaultAsync().ConfigureAwait(false);
        
        return _mapper.Map<TModel>(entity);
    }

    public async Task<IEnumerable<TModel>> GetListAsync(ISpecification<TModel> specification)
    {
        var entitySpecification = _mapper.Map<BaseSpecification<TEntity>>(specification);

        var query = _testDb.GetTable<TEntity>().Specify(entitySpecification);

        var entity = await query.ToListAsync().ConfigureAwait(false);
        
        return _mapper.Map<IEnumerable<TModel>>(entity);
    }
}