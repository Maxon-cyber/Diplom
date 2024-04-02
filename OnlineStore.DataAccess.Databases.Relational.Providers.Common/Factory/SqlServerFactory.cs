using System.Data.Common;

namespace OnlineStore.DataAccess.Databases.Relational.Providers.Common.Factory;

public sealed class SqlServerFactory : DatabaseConnection
{
    public SqlConnection Connection { get => base.Connection; set => base.Connection = value; }
    
    public override void Close()
    {
        throw new NotImplementedException();
    }
}