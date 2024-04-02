using System.Data.Common;

namespace OnlineStore.DataAccess.Databases.Relational.Providers.Common;

public abstract class DatabaseConnection
{
    public bool Opened { get; set; }

    public virtual DbConnection Connection { get; set; }

    public DbCommand Command { get; set; }

    public DbTransaction Transaction { get; set; }

    public abstract void Close();
}