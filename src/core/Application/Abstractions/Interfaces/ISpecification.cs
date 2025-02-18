using System.Linq.Expressions;

namespace Application.Abstractions.Interfaces;

public interface ISpecification<TModel>
{
    List<Expression<Func<TModel, bool>>> WhereExpressions { get; }
    List<Expression<Func<TModel, object>>> LoadWithExpressions{ get; }
    List<Expression<Func<TModel, object>>> OrderByExpressions { get; }
    List<Expression<Func<TModel, object>>> OrderByDescExpressions { get; }

    void AddWhere(Expression<Func<TModel, bool>> expression);
    void AddLoadWith(Expression<Func<TModel, object>> expression);

    void AddWhere(IEnumerable<Expression<Func<TModel, bool>>> expressions);
    void AddLoadWith(IEnumerable<Expression<Func<TModel, object>>> expressions);
    void AddOrderBy(Expression<Func<TModel, object>> expression);
    void AddOrderByDesc(Expression<Func<TModel, object>> expression);
    void AddOrderBy(IEnumerable<Expression<Func<TModel, object>>> expressions);
    void AddOrderByDesc(IEnumerable<Expression<Func<TModel, object>>> expressions);

    int? Page { get; set; }
    int? CountOnPage { get; set; }
}