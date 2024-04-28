using OnlineStore.UI.Mvp.Views;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Forms.MainWindow.Tabs.ShoppingCard;

public sealed partial class ShoppngCartControl : UserControl, IShoppingCartView
{
    public event Action Order;

    public UserControl Instance => this;

    public ShoppngCartControl()
    {
        InitializeComponent();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }
}