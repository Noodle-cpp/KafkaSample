namespace Api.ViewModels.Responses;

public class BookResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public Guid AuthorId { get; init; }
    public AuthorResponse Author { get; init; } = new();
}