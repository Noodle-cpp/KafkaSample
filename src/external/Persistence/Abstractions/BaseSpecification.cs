using System.Linq.Expressions;

namespace Persistence.Abstractions;

public class BaseSpecification<TEntity>
{

    public Expression<Func<TEntity, bool>> Criteria { get; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }
    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

    protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
    {
        OrderByDescending = orderByDescendingExpression;
    }
}