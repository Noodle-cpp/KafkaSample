using Domain.Abstractions;
using LinqToDB.Mapping;

namespace Domain.Entities;

[Table("Authors")]
public class Author : BaseEntity
{
    [Column, NotNull]
    public string FIO { get; set; }
    
    [Column, NotNull]
    public DateTime DateOfBirth { get; set; }
}