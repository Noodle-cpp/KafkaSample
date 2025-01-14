namespace Api.ViewModels.Responses;

public class AuthorResponse
{
    public Guid Id { get; init; }
    public string FIO { get; init; }
    public DateTime DateOfBirth { get; init; }
}