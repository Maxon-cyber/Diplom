using OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer;
using OnlineStore.Service.SqlServer.Product;
using OnlineStore.Service.SqlServer.User;

namespace OnlineStore.Service.SqlServer;

public sealed class SqlServerService(SqlServerFacade sqlServerFacade) : IDisposable, IAsyncDisposable
{
    private readonly Lazy<UserService> _userService = new Lazy<UserService>(() => new UserService(sqlServerFacade.UserRepository));
    private readonly Lazy<ProductService> _productService = new Lazy<ProductService>(() => new ProductService(sqlServerFacade.ProductRepository));

    public UserService User => _userService.Value;

    public ProductService Product => _productService.Value;

    public void Dispose()
    {
        User?.Dispose();

        Product?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (User != null)
            await User.DisposeAsync();

        if (Product != null)
            await Product.DisposeAsync();
    }
}