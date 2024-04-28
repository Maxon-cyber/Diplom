using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer.Repositories;

namespace OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer;

public sealed class SqlServerFacade(SqlServerProvider sqlServerProvider)
{
    private readonly Lazy<UserRepository> _userRepository = new Lazy<UserRepository>(() => new UserRepository(sqlServerProvider));
    private readonly Lazy<ProductRepository> _productRepository = new Lazy<ProductRepository>(() => new ProductRepository(sqlServerProvider));

    public UserRepository UserRepository => _userRepository.Value;

    public ProductRepository ProductRepository => _productRepository.Value;
}