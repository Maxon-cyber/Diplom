using Microsoft.Data.SqlClient;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.Product;
using OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.User;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Relational.SqlServer;

public sealed class SqlServerProvider : DbProvider
{
    private readonly DatabaseParameters _databaseParameters;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IProductRepository> _productRepository;

    public override string Provider { get; }

    public IUserRepository UserRepository => _userRepository.Value;

    public IProductRepository ProductRepository => _productRepository.Value;

    public override SqlConnection Connection => CreateConnection();

    public override SqlCommand Command => CreateCommand(Connection);

    public SqlServerProvider(DatabaseParameters databaseparameters)
    {
        _databaseParameters = databaseparameters;
        Provider = _databaseParameters.Provider;

        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(this));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(this));
    }

    protected override SqlCommand CreateCommand(DbConnection connection)
        => new SqlCommand()
        {
            Connection = (connection as SqlConnection) ?? throw new ArgumentNullException(nameof(connection)),
            CommandTimeout = connection.ConnectionTimeout
        };

    protected override SqlConnection CreateConnection()
    {
        SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder
        {
            DataSource = $"{_databaseParameters.Server},{_databaseParameters.Port}",
            InitialCatalog = _databaseParameters.Database,
            IntegratedSecurity = _databaseParameters.IntegratedSecurity
        };

        if (!_databaseParameters.IntegratedSecurity)
        {
            sqlConnectionBuilder.UserID = _databaseParameters.Username;
            sqlConnectionBuilder.Password = _databaseParameters.Password;
        }

        sqlConnectionBuilder.TrustServerCertificate = _databaseParameters.TrustServerCertificate;

        if (_databaseParameters.ConnectionTimeout.HasValue)
            sqlConnectionBuilder.ConnectTimeout = (int)_databaseParameters.ConnectionTimeout.Value.TotalSeconds;
        if (_databaseParameters.MaxPoolSize.HasValue)
            sqlConnectionBuilder.MaxPoolSize = _databaseParameters.MaxPoolSize.Value;

        return new SqlConnection(sqlConnectionBuilder.ToString());
    }
}