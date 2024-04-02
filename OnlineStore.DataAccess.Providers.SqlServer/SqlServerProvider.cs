using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.SqlServer;

public sealed class SqlServerProvider(DatabaseParameters parameters) : DbProvider(parameters)
{
    public override string ConnectionString { get; protected set; }

    public override SqlCommand CreateCommand(DbConnection connection)
        => new SqlCommand()
        {
            Connection = connection as SqlConnection,
            CommandTimeout = connection.ConnectionTimeout
        };

    public override SqlConnection CreateConnection()
    {
        SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder
        {
            DataSource = $"{parameters.Server},{parameters.Port}",
            InitialCatalog = parameters.Database,
            IntegratedSecurity = parameters.IntegratedSecurity
        };

        if (!parameters.IntegratedSecurity)
        {
            sqlConnectionBuilder.UserID = parameters.Username;
            sqlConnectionBuilder.Password = parameters.Password;
        }

        sqlConnectionBuilder.TrustServerCertificate = parameters.TrustServerCertificate;

        if (parameters.ConnectionTimeout.HasValue)
            sqlConnectionBuilder.ConnectTimeout = (int)parameters.ConnectionTimeout.Value.TotalSeconds;
        if (parameters.MaxPoolSize.HasValue)
            sqlConnectionBuilder.MaxPoolSize = parameters.MaxPoolSize.Value;

        ConnectionString = sqlConnectionBuilder.ToString();
        return new SqlConnection(ConnectionString);
    }
}