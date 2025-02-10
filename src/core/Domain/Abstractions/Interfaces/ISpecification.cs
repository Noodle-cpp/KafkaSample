using System.Linq.Expressions;

namespace Persistence.Abstractions.Interfaces;

public interface ISpecification<TEntity>
{
    List<Expression<Func<TEntity, bool>>> WhereExpressions { get; }
    List<Expression<Func<TEntity, object>>> OrderByExpressions { get; }
    List<Expression<Func<TEntity, object>>> OrderByDescExpressions { get; }
    // List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> LoadWithExpressions{ get; }
    List<Expression<Func<TEntity, object>>> LoadWithExpressions{ get; }

    void Where(Expression<Func<TEntity, bool>> exp);
    void OrderBy(Expression<Func<TEntity, object>> exp);
    void OrderByDesc(Expression<Func<TEntity, object>> exp);
    // void LoadWith(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> exp);
    void LoadWith(Expression<Func<TEntity, object>> exp);
    
    int? Page { get; set; }
    int? CountOnPage { get; set; }
}