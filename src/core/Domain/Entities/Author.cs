using Domain.Abstractions;

namespace Domain.Entities;

public class Author : BaseEntity
{
    public string FIO { get; set; }
    public DateTime DateOfBirth { get; set; }
}