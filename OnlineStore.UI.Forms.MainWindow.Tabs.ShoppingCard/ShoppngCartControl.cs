using OnlineStore.UI.Mvp.Common;
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

    public void ShowMessage(string message, MessageLevel messageLevel = MessageLevel.Information)
    {
        throw new NotImplementedException();
    }
}