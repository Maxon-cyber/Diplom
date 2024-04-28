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
    private readonly Panel _mainPanel;

    public MainWindowPresenter(IMainWindowView view, IUserAccountView userAccountView, IProductShowcaseView productShowcaseView, IShoppingCartView shoppingCartView, IApplicationController controller)
        : base(view, controller)
    {
        View.UserAccount += () => OpenUserAccount(userAccountView);
        View.ProductShowcase += () => OpenProductShowcase(productShowcaseView);
        View.ShoppingCart += () => OpenShoppingCart(shoppingCartView);

        _mainPanel = View.Instance.Controls.Find("panelMain", false).FirstOrDefault() as Panel;
    }

    public override void Run(UserEntity argument)
    {
        _user = argument;
        View.Show();
    }

    private void OpenUserAccount(IUserAccountView userAccountView)
       => Controller.RunAsChildControl<UserAccountPresenter, UserEntity>(_user, _mainPanel, userAccountView.Instance);

    private void OpenProductShowcase(IProductShowcaseView productShowcaseView)
       => Controller.RunAsChildControl<ProductShowcasePresenter>(_mainPanel, productShowcaseView.Instance);

    private void OpenShoppingCart(IShoppingCartView shoppingCartView)
       => Controller.RunAsChildControl<ShoppingCartPresenter, Guid>(_user.Id, _mainPanel, shoppingCartView.Instance);
}