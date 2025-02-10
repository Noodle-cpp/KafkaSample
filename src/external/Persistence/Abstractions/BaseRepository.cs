using AutoMapper;
using Domain.Abstractions;
using Domain.Models;
using LinqToDB;
using Persistence.Abstractions.Interfaces;
using Persistence.Extensions;

namespace Persistence.Abstractions;

public class BaseRepository<TEntity> : BaseSpecification<TEntity>, IRepository<TEntity>
    where TEntity : class
{
    private readonly IMapper _mapper;
    private readonly TestDbdb _testDb;

    public BaseRepository(TestDbdb testDb, IMapper mapper)
    {
        _mapper = mapper;
        _testDb = testDb;
    }

    public async Task<TEntity?> GetAsync(ISpecification<TEntity> specification)
    {
        var query = from b in _testDb.GetTable<TEntity>()
                                                            .Specify<TEntity>(specification)
                                    select b;

        var entity = await query.SingleOrDefaultAsync().ConfigureAwait(false);
        
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification)
    {
        var query = from b in _testDb.GetTable<TEntity>()
                                                            .Specify<TEntity>(specification)
                                    select b;

        var entity = await query.ToListAsync().ConfigureAwait(false);
        
        return entity;
    }
}