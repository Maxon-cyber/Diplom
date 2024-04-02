using Microsoft.Data.SqlClient;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer.Repositories;
using OnlineStore.Domain.Product;
using OnlineStore.Domain.User;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;

public sealed class SqlServer : DbProvider
{
    private readonly Lazy<IRepository<UserEntity>> _userRepository;
    private readonly Lazy<IRepository<ProductEntity>> _productRepository;

    public override string Prefix => "@";

    public IRepository<UserEntity> UserRepository => _userRepository.Value;

    public IRepository<ProductEntity> ProductRepository => _productRepository.Value;

    public SqlServer(ConnectionParameters connectionParameters)
        : base(connectionParameters)
    {
        SqlConnection dbConnection = CreateConnection();
        _userRepository = new Lazy<IRepository<UserEntity>>(() => new UserRepository(dbConnection, CreateCommand(dbConnection), Prefix));
        _productRepository = new Lazy<IRepository<ProductEntity>>(() => new ProductRepository(dbConnection, CreateCommand(dbConnection), Prefix));
    }

    protected override SqlCommand CreateCommand(DbConnection connection)
        => new SqlCommand()
        {
            Connection = connection as SqlConnection ?? throw new ArgumentNullException(nameof(connection)),
            CommandTimeout = 30
        };

    protected override SqlConnection CreateConnection()
    {
        SqlConnectionStringBuilder sqlConnectionBuilder = new SqlConnectionStringBuilder
        {
            DataSource = $@"{_connectionParameters.Server},{_connectionParameters.Port}",
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

        return new SqlConnection(sqlConnectionBuilder.ToString());
    }

    public override void Dispose()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        UserRepository.Dispose();
        ProductRepository.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        await UserRepository.DisposeAsync();
        await ProductRepository.DisposeAsync();
    }
}