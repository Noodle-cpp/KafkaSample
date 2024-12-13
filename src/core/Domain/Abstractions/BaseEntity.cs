using LinqToDB.Mapping;

namespace Domain.Abstractions;

public abstract class BaseEntity
{
    [PrimaryKey, Identity]
    public Guid Id { get; init; } = Guid.NewGuid();
}