using OnlineStore.DataAccess;
using OnlineStore.Service.Product;
using OnlineStore.Service.User;

namespace OnlineStore.Service;

public sealed partial class ServiceFacade(DatabaseFacade databaseFacade) : IDisposable, IAsyncDisposable
{
    public IUserService User => _userService.Value;

    public IProductService Product => _productService.Value;

    public void Dispose()
    {
        User.Dispose();
        Product.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await User.DisposeAsync();
        await Product.DisposeAsync();
    }
}