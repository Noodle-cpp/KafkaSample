namespace Api.ViewModels.Responses;

public class BookResponse
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Guid AuthorId { get; private set; }
    public AuthorResponse Author { get; private set; }
}