using Domain.Abstractions;

namespace Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}