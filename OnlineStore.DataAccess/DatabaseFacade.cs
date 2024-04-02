using OnlineStore.DataAccess.Databases;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;

namespace OnlineStore.DataAccess;

public sealed class DatabaseFacade(IDictionary<string, ConnectionParameters> parametersOfAllDatabases) : IDisposable, IAsyncDisposable
{
    public RelationalDbStrategy Relational { get; } = new RelationalDbStrategy(parametersOfAllDatabases);

    public void Dispose()
    {
        Relational.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await Relational.DisposeAsync();
    }
}