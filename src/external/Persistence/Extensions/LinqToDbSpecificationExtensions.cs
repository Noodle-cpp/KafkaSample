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
        
        //
        // if (specification.OrderByExpressions.Count != 0)
        // {
        //     IOrderedQueryable<TEntity> orderedQuery = query.OrderBy(specification.OrderByExpressions.First());
        //     foreach (var orderBy in specification.OrderByExpressions.Skip(1))
        //     {
        //         orderedQuery = orderedQuery.ThenBy(orderBy);
        //     }
        //
        //     query = orderedQuery;
        // }
        // else if (specification.OrderByDescExpressions.Count != 0)
        // {
        //     IOrderedQueryable<TEntity> orderedQuery = query.OrderByDescending(specification.OrderByDescExpressions.First());
        //
        //     foreach (var orderByDesc in specification.OrderByDescExpressions.Skip(1))
        //     {
        //         orderedQuery = orderedQuery.ThenByDescending(orderByDesc);
        //     }
        //
        //     query = orderedQuery; 
        // }
        
        // if (!specification.Page.HasValue || !specification.CountOnPage.HasValue) return query;
        // if (specification.Page.Value < 1 || specification.CountOnPage.Value < 1)
        //     throw new ArgumentException("Page and CountOnPage must be greater than 0.");
        //
        // var skip = (specification.Page.Value - 1) * specification.CountOnPage.Value;
        // query = query.Skip(skip).Take(specification.CountOnPage.Value);

        return result;
    }
}