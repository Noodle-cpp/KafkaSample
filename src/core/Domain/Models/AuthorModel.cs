namespace Domain.Models;

public class AuthorModel
{
    public string Id  { get; set; } = null!;
    public string? Fio         { get; set; } 
    public DateTime? DateOfBirth { get; set; }
}