using OnlineStore.Service.SqlServer;

namespace OnlineStore.Service;

public sealed partial class ServiceFacade
{
    private readonly Lazy<SqlServerService> _sqlServerService = new Lazy<SqlServerService>(() => new SqlServerService(databaseFacade.Relational.SqlServer));
}