using OnlineStore.Domain;
using System.Collections.Immutable;

namespace OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;

public sealed class DbResponse<TEntity>()
    where TEntity : Entity, new()
{
    public IImmutableQueue<TEntity>? Data { get; set; }

    public IImmutableDictionary<TEntity, bool>? AddedData { get; set; }

    public string? Message { get; set; }

    public Exception? Exception { get; set; }
}