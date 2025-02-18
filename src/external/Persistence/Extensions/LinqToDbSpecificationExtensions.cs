using Application.Abstractions.Interfaces;
using LinqToDB;

namespace Persistence.Extensions;

public static class LinqToDbSpecificationExtensions
{
    public static IQueryable<TEntity> Specify<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(specification);
        
        var result = specification.LoadWithExpressions.Aggregate(query, (current, with) => current.LoadWith(with));
        result = specification.WhereExpressions.Aggregate(result, (current, where) => current.Where(where));
        
        if (specification.OrderByExpressions.Count != 0)
        {
            result = result.OrderBy(specification.OrderByExpressions.First());
            result = specification.OrderByExpressions.Skip(1).Aggregate(result, (current, orderBy) => current.ThenOrBy(orderBy));
        }
        else if (specification.OrderByDescExpressions.Count != 0)
        {
            result = result.OrderByDescending(specification.OrderByDescExpressions.First());
            result = specification.OrderByDescExpressions.Skip(1).Aggregate(result, (current, orderByDesc) => current.ThenOrByDescending(orderByDesc));
        }
        
        if (!specification.Page.HasValue || !specification.CountOnPage.HasValue) return result;
        if (specification.Page.Value < 1 || specification.CountOnPage.Value < 1)
            throw new ArgumentException("Page and CountOnPage must be greater than 0.");
        
        var skip = (specification.Page.Value - 1) * specification.CountOnPage.Value;
        return result.Skip(skip).Take(specification.CountOnPage.Value);
    }
}