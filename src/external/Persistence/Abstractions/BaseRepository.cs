using Domain.Models;
using LinqToDB;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Abstractions;

public abstract class BaseRepository<TEntity, TModel>(TestDbdb testDb) where TEntity : class 
                                                                        where TModel : class 
{
    private readonly TestDbdb _testDb = testDb;

    protected async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await AsyncExtensions.ToListAsync(_testDb.GetTable<TEntity>()).ConfigureAwait(false);
    }

    protected async Task<TEntity?> GetByIdAsync(string id)
    {
        return await AsyncExtensions.FirstOrDefaultAsync(_testDb.GetTable<TEntity>(), x => EF.Property<string>(x, "Id") == id).ConfigureAwait(false);
    }

    protected async Task CreateAsync(TEntity entity)
    {
        await _testDb.InsertAsync(entity).ConfigureAwait(false);
    }
}