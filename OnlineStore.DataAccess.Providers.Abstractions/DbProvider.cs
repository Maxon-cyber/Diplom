using OnlineStore.DataAccess.Providers.SqlServer.Models;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Abstractions;

public abstract class DbProvider(DatabaseParameters options)
{
    public abstract string ConnectionString { get; protected set; }

    public abstract DbCommand CreateCommand(DbConnection connection);

    public abstract DbConnection CreateConnection();
}