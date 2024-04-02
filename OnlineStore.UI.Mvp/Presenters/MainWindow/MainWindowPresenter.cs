using OnlineStore.Domain.User;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs;
using OnlineStore.UI.Mvp.Views.MainWindow;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow;

public sealed class MainWindowPresenter : Presenter<IMainWindowView, UserEntity>
{
    private UserEntity _user;

    public MainWindowPresenter(IMainWindowView view, IUserAccountView userAccountView, IProductShowcaseView productShowcaseView, IShoppingCartView shoppingCartView, IApplicationController controller)
        : base(view, controller)
    {
        View.UserAccount += () => OpenUserAccount(userAccountView);
        View.ProductShowcase += () => OpenProductShowcase(productShowcaseView);
        View.ShoppingCart += () => OpenShoppingCart(shoppingCartView);
    }

    public override void Run(UserEntity argument)
    {
        _user = argument;
        View.Show();
    }

    private void OpenUserAccount(IUserAccountView userAccountView)
       => Controller.RunAsChildControl<UserAccountPresenter, UserEntity>(_user, View.Instance, userAccountView.Instance);

    private void OpenProductShowcase(IProductShowcaseView productShowcaseView)
       => Controller.RunAsChildControl<ProductShowcasePresenter>(View.Instance, productShowcaseView.Instance);

    private void OpenShoppingCart(IShoppingCartView shoppingCartView)
       => Controller.RunAsChildControl<ShoppingCartPresenter, ulong>(_user.Id, View.Instance, shoppingCartView.Instance);
}