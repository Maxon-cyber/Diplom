using OnlineStore.DataAccess;
using OnlineStore.Service.SqlServer;

namespace OnlineStore.Service;

public sealed partial class ServiceFacade(DatabaseFacade databaseFacade) : IDisposable, IAsyncDisposable
{
    public SqlServerService SqlServer => _sqlServerService.Value;

    public void Dispose()
    {
        SqlServer?.Dispose();

        databaseFacade?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await SqlServer.DisposeAsync();

        await databaseFacade.DisposeAsync();
    }
}