using System.Linq.Expressions;

namespace Persistence.Abstractions;

public class Specification<TEntity>
{
    public Expression<Func<TEntity, bool>> Criteria { get; private set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
    
    public int? Take { get; private set; }
    public int? Skip { get; private set; }
    
    public void AddCriteria(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;    
    }

    public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    public void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    public void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }
    
    public void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }
}