using OnlineStore.Service.Product;
using OnlineStore.Service.User;

namespace OnlineStore.Service;

public sealed partial class ServiceFacade
{
    private readonly Lazy<IUserService> _userService = new Lazy<IUserService>(() => new UserService(databaseFacade));
    private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(databaseFacade));
}