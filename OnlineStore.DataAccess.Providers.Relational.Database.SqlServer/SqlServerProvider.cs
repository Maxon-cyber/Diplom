using Microsoft.Data.SqlClient;
using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common.Models;

namespace OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;

public sealed class SqlServerProvider : DbProvider
{
    private readonly ADOEntityDataAccessService _ado;

    public SqlServerProvider(ConnectionParameters connectionParameters) : base(connectionParameters)
        => _ado = new ADOEntityDataAccessService(Provider, Prefix, DbConnection, DbCommand);

    public override string Prefix => "@";

    public override string Provider => "SqlServerProvider";

    public override SqlConnection DbConnection
    {
        get
        {
            SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = $"{_connectionParameters.Server}",
                InitialCatalog = _connectionParameters.Database,
                IntegratedSecurity = _connectionParameters.IntegratedSecurity
            };

            if (!_connectionParameters.IntegratedSecurity)
            {
                sqlConnectionBuilder.UserID = _connectionParameters.Username;
                sqlConnectionBuilder.Password = _connectionParameters.Password;
            }

            sqlConnectionBuilder.TrustServerCertificate = _connectionParameters.TrustServerCertificate;

            if (_connectionParameters.ConnectionTimeout.HasValue)
                sqlConnectionBuilder.ConnectTimeout = (int)_connectionParameters.ConnectionTimeout.Value.TotalSeconds;
            if (_connectionParameters.MaxPoolSize.HasValue)
                sqlConnectionBuilder.MaxPoolSize = _connectionParameters.MaxPoolSize.Value;

            _dbConnection = new SqlConnection(sqlConnectionBuilder.ToString());

            return (_dbConnection as SqlConnection)!;
        }
    }

    public override SqlCommand DbCommand
    {
        get
        {
            if (_dbConnection == null)
                throw new Exception();

            _dbCommand = new SqlCommand()
            {
                Connection = _dbConnection as SqlConnection,
                CommandTimeout = 30
            };

            return (_dbCommand as SqlCommand)!;
        }
    }

    public override Task<DbResponse<TEntity>> GetByAsync<TEntity>(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token)
        => _ado.GetEntityByAsync(queryParameters, entityCondition, token);

    public override Task<DbResponse<TEntity>> SelectAsync<TEntity>(QueryParameters queryParameters, CancellationToken token)
        => _ado.SelectEntitiesAsync<TEntity>(queryParameters, token);

    public override Task<DbResponse<TEntity>> SelectByAsync<TEntity>(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token)
        => _ado.SelectEntitiesByAsync(queryParameters, entityCondition, token);

    public override Task<DbResponse<TEntity>> ChangeAsync<TEntity>(QueryParameters queryParameters, TEntity entity, CancellationToken token)
        => _ado.ChangeEntityAsync(queryParameters, entity, token);

    public override Task<IEnumerable<DbResponse<TEntity>>> ChangeAsync<TEntity>(QueryParameters queryParameters, IEnumerable<TEntity> entities, CancellationToken token)
         => _ado.ChangeEntityAsync(queryParameters, entities, token);

    public override void Dispose()
        => _ado.Dispose();

    public override async ValueTask DisposeAsync()
        => await _ado.DisposeAsync();
}