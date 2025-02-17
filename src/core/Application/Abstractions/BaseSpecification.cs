using System.Linq.Expressions;
using Application.Abstractions.Interfaces;

namespace Application.Abstractions;

public class BaseSpecification<TEntity> : ISpecification<TEntity>
{
    public int? Page { get; set; }
    public int? CountOnPage { get; set; }

    public List<Expression<Func<TEntity, bool>>> WhereExpressions { get; } = [];

    public List<Expression<Func<TEntity, object>>> OrderByExpressions { get; } = [];

    public List<Expression<Func<TEntity, object>>> OrderByDescExpressions { get; } = [];

    public List<Expression<Func<TEntity, object>>> LoadWithExpressions { get; } = [];

    public void LoadWith(Expression<Func<TEntity, object>> exp)
    {
        LoadWithExpressions.Add(exp);
    }

    public void OrderBy(Expression<Func<TEntity, object>> exp)
    {            
        OrderByExpressions.Add(exp);            
    }

    public void OrderByDesc(Expression<Func<TEntity, object>> exp)
    {
        OrderByDescExpressions.Add(exp);
    }

    public void Where(Expression<Func<TEntity, bool>> exp)
    {
        WhereExpressions.Add(exp);
    }
}