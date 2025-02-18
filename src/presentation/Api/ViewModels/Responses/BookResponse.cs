namespace Api.ViewModels.Responses;

public class BookResponse
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? AuthorId { get; set; }
    public AuthorResponse? Author { get; set; }
}