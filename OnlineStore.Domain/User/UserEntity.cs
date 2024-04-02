using OnlineStore.Domain.Attributes;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace OnlineStore.Domain.User;

public sealed class UserEntity() : Entity
{
    [NotNull]
    [ColumnData(ColumnName = "name", SqlDbType = SqlDbType.NChar)]
    public string Name { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "second_name", SqlDbType = SqlDbType.NChar)]
    public string SecondName { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "patronymic", SqlDbType = SqlDbType.NChar)]
    public string Patronymic { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "gender", SqlDbType = SqlDbType.NChar)]
    public Gender Gender { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "age", SqlDbType = SqlDbType.SmallInt)]
    public uint Age { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "location", SqlDbType = SqlDbType.BigInt)]
    public Location Location { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "login", SqlDbType = SqlDbType.NChar)]
    public string Login { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "password", SqlDbType = SqlDbType.NChar)]
    public string Password { get; init; }

    [NotNull]
    [ColumnData(ColumnName = "role", SqlDbType = SqlDbType.NChar)]
    public Role Role { get; init; }

    public override string ToString()
       => $"{Name} {SecondName} {Patronymic}";

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}