using System.Collections.Immutable;

namespace OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;

public sealed class DbResponse<TResponse>()
{
    public IImmutableQueue<TResponse> QueryResult { get; } = ImmutableQueue.Create<TResponse>();

    public object? OutputValue { get; set; }

    public object? ReturnedValue { get; set; }

    public IImmutableDictionary<string, object> AdditionalData { get; } = ImmutableDictionary<string, object?>.Empty;
    
    public string? Message { get; set; }

    public Exception? Exception { get; set; }
}