using LinqToDB;
using Persistence.Abstractions.Interfaces;

namespace Persistence.Extensions;

public static class LinqToDbSpecificationExtensions
{
    public static IQueryable<TEntity> Specify<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(specification);

        query = specification.WhereExpressions.Aggregate(query, (current, whereExpression) => current.Where(whereExpression));

        query = specification.OrderByExpressions.Aggregate(query, (current, orderByExpression) => current.OrderBy(orderByExpression));

        query = specification.OrderByDescExpressions.Aggregate(query, (current, orderByDescExpression) => current.OrderByDescending(orderByDescExpression));

        query = specification.LoadWithExpressions.Aggregate(query, (current, loadWithExpression) => current.LoadWith(loadWithExpression));
        
        if (!specification.Page.HasValue || !specification.CountOnPage.HasValue) return query;
        
        var skip = (specification.Page.Value - 1) * specification.CountOnPage.Value;
        query = query.Skip(skip).Take(specification.CountOnPage.Value);

        return query;
    }
}