using System.Linq.Expressions;
using System.Xml.Serialization;
using Application.Abstractions.Interfaces;
using AutoMapper;

namespace Persistence.Abstractions;

public class BaseSpecification<TModel> : ISpecification<TModel>
where TModel : class
{
    public int? Page { get; set; }
    public int? CountOnPage { get; set; }
    public List<Expression<Func<TModel, bool>>> WhereExpressions { get; } = [];
    public List<Expression<Func<TModel, object>>> LoadWithExpressions { get; } = [];
    public List<Expression<Func<TModel, object>>> OrderByExpressions { get; } = [];
    public List<Expression<Func<TModel, object>>> OrderByDescExpressions { get; } = [];

    public void AddWhere(Expression<Func<TModel, bool>> expression)
    {
        WhereExpressions.Add(expression);
    }

    public void AddLoadWith(Expression<Func<TModel, object>> expression)
    {
        LoadWithExpressions.Add(expression);
    }

    public void AddWhere(IEnumerable<Expression<Func<TModel, bool>>> expressions)
    {
        WhereExpressions.AddRange(expressions);
    }

    public void AddLoadWith(IEnumerable<Expression<Func<TModel, object>>> expressions)
    {
        LoadWithExpressions.AddRange(expressions);
    }

    public void AddOrderBy(Expression<Func<TModel, object>> expression)
    {
        OrderByExpressions.Add(expression);
    }

    public void AddOrderByDesc(Expression<Func<TModel, object>> expression)
    {
        OrderByDescExpressions.Add(expression);
    }

    public void AddOrderBy(IEnumerable<Expression<Func<TModel, object>>> expressions)
    {
        OrderByExpressions.AddRange(expressions);
    }

    public void AddOrderByDesc(IEnumerable<Expression<Func<TModel, object>>> expressions)
    {
        OrderByDescExpressions.AddRange(expressions);
    }
}