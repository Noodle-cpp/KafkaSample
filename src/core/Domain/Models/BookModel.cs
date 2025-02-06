namespace Domain.Models;

public class BookModel
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? AuthorId { get; set; }
    public AuthorModel? Author { get; set; }
}