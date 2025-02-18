using System.Linq.Expressions;
using Application.Abstractions;
using Application.Abstractions.Interfaces;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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
        var spec = MapToEntitySpecification(specification);
        
        var query = _testDb.GetTable<TEntity>().Specify(spec);;
        
        var entity = await query.SingleOrDefaultAsync().ConfigureAwait(false);
        
        return _mapper.Map<TModel>(entity);
    }

    public async Task<IEnumerable<TModel>> GetListAsync(ISpecification<TModel> specification)
    {
        var spec = MapToEntitySpecification(specification);
        
        var query = _testDb.GetTable<TEntity>().Specify(spec);
        
        var entity = await query.ToListAsync().ConfigureAwait(false);
        
        return _mapper.Map<IEnumerable<TModel>>(entity);
    }

    private ISpecification<TEntity> MapToEntitySpecification(ISpecification<TModel> specification)
    {
        var newSpec = new BaseSpecification<TEntity>();
        
        newSpec.AddWhere(specification.WhereExpressions.Select(s => _mapper.MapExpression<Expression<Func<TEntity, bool>>>(s)));
        newSpec.AddLoadWith(specification.LoadWithExpressions.Select(s => _mapper.MapExpression<Expression<Func<TEntity, object>>>(s)));
        newSpec.AddOrderBy(specification.OrderByExpressions.Select(s => _mapper.MapExpression<Expression<Func<TEntity, object>>>(s)));
        newSpec.AddOrderByDesc(specification.OrderByDescExpressions.Select(s => _mapper.MapExpression<Expression<Func<TEntity, object>>>(s)));
        newSpec.Page = specification.Page;
        newSpec.CountOnPage = specification.CountOnPage;
        
        return newSpec;
    }
}