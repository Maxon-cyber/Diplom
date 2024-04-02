namespace OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

public interface IShoppingCartView : IView
{
    event Action Order;

    UserControl Instance { get; }
}
