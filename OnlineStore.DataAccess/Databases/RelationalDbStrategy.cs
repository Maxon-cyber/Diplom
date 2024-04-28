using OnlineStore.DataAccess.Databases.Exceptions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common.Models;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer;
using System.Reflection;

namespace OnlineStore.DataAccess.Databases;

file enum ListOfRelationalDatabases
{
    SqlServer = 0,
}

public sealed class RelationalDbStrategy : IDisposable, IAsyncDisposable
{
    public SqlServerFacade SqlServer { get; }

    internal RelationalDbStrategy(IDictionary<string, ConnectionParameters> parametersOfAllDatabases)
    {
        foreach (string currentKey in parametersOfAllDatabases.Keys)
        {
            ConnectionParameters currentValue = parametersOfAllDatabases[currentKey];

            if (!Enum.TryParse(currentValue.Provider, true, out ListOfRelationalDatabases result))
                throw new DbProviderHasNotBeenAddedException("Провайдер не добавлен в перечисление используемых провайдеров");

            switch (result)
            {
                case ListOfRelationalDatabases.SqlServer:
                    SqlServer = new SqlServerFacade(new SqlServerProvider(currentValue));
                    break;
            }
        }
    }

    public void Dispose()
    {
        PropertyInfo[] properties = GetType().GetProperties();

        foreach (PropertyInfo propertyInfo in properties)
            if (propertyInfo.PropertyType is IDisposable disposable)
                disposable.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        PropertyInfo[] properties = GetType().GetProperties();

        foreach (PropertyInfo propertyInfo in properties)
            if (propertyInfo.PropertyType is IAsyncDisposable asyncDisposable)
                await asyncDisposable.DisposeAsync();
    }
}