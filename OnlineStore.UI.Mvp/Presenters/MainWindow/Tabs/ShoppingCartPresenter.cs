using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs;

public sealed class ShoppingCartPresenter : Presenter<IShoppingCartView, ulong>
{
    private ulong _userId;

    public ShoppingCartPresenter(IShoppingCartView view, IApplicationController controller)
        : base(view, controller)
    {
        View.Order += Order;
    }

    public override void Run(ulong argument)
    {
        _userId = argument;
        View.Show();
    }

    private async void Order()
    {

    }
}