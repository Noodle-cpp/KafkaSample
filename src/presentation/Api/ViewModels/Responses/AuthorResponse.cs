namespace Api.ViewModels.Responses;

public class AuthorResponse
{
    public string Id { get; set; } = null!;
    public string? Fio { get; set; } 
    public DateTime? DateOfBirth { get; set; }
}