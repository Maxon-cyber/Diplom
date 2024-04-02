using System.Diagnostics.CodeAnalysis;

namespace OnlineStore.Domain.User;

public sealed class Location()
{
    [NotNull]
    public string HouseNumber { get; set; }

    [NotNull]
    public string Street { get; set; }

    [NotNull]
    public string City { get; init; }

    [NotNull]
    public string Region { get; init; }

    [NotNull]
    public string Country { get; init; }
}