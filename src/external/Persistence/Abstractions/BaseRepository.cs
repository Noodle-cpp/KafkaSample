using AutoMapper;
using Domain.Models;
using LinqToDB;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Abstractions;

public abstract class BaseRepository<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    private readonly IMapper _mapper;
    private readonly TestDbdb _testDb;

    protected BaseRepository(TestDbdb testDb, IMapper mapper)
    {
        _mapper = mapper;
        _testDb = testDb;
    }
    
    protected async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await AsyncExtensions.ToListAsync(_testDb.GetTable<TEntity>()).ConfigureAwait(false);
        return _mapper.Map<IEnumerable<TModel>>(entities);
    }

    protected async Task<TModel?> GetByIdAsync(string id)
    {
        var entity = await AsyncExtensions.FirstOrDefaultAsync(_testDb.GetTable<TEntity>(), x => EF.Property<string>(x, "Id") == id).ConfigureAwait(false);
        return _mapper.Map<TModel>(entity);
    }

    protected async Task CreateAsync(TEntity entity)
    {
        await _testDb.InsertAsync(entity).ConfigureAwait(false);
    }
}