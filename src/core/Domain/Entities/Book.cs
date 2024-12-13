using Domain.Abstractions;
using LinqToDB.Mapping;

namespace Domain.Entities;

public class Book : BaseEntity
{
    [Column, NotNull]
    public string Title { get; set; }
    
    [Column, NotNull]
    public Guid AuthorId { get; set; }
    
    [Association(ThisKey = nameof(AuthorId), OtherKey = nameof(Author.Id))]
    public Author Author { get; set; }
}