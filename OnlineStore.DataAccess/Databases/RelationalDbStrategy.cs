using OnlineStore.DataAccess.Databases.Exceptions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using System.Diagnostics.CodeAnalysis;

namespace OnlineStore.DataAccess.Databases;

file enum ListOfRelationalDatabases
{
    SqlServer = 0,
}

public sealed class RelationalDbStrategy : IDisposable, IAsyncDisposable
{
    private readonly List<DbProvider> _providers;

    [MemberNotNullWhen(true, nameof(SqlServer))]
    public SqlServer SqlServer { get; }

    internal RelationalDbStrategy(IDictionary<string, ConnectionParameters> parametersOfAllDatabases)
    {
        _providers = new List<DbProvider>();

        foreach (string currentKey in parametersOfAllDatabases.Keys)
        {
            ConnectionParameters currentValue = parametersOfAllDatabases[currentKey];

            if (!Enum.TryParse(currentValue.Provider, true, out ListOfRelationalDatabases result))
                throw new DbProviderHasNotBeenAddedException("Провайдер не добавлен в перечисление используемых провайдеров");

            switch (result)
            {
                case ListOfRelationalDatabases.SqlServer:
                    SqlServer = new SqlServer(currentValue);
                    _providers.Add(SqlServer);
                    break;
            }
        }
    }

    public void Dispose()
    {
        foreach (DbProvider provider in _providers)
            provider.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        foreach (DbProvider provider in _providers)
            await provider.DisposeAsync();
    }
}