using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Relational.Abstractions;

public abstract class DbProvider : IDisposable, IAsyncDisposable
{
    protected readonly ConnectionParameters _connectionParameters;

    public abstract string Prefix { get; }

    protected DbProvider(ConnectionParameters connectionParameters)
        => _connectionParameters = connectionParameters;

    protected abstract DbCommand CreateCommand(DbConnection connection);

    protected abstract DbConnection CreateConnection();

    public abstract void Dispose();

    public abstract ValueTask DisposeAsync();
}