namespace OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

public interface IProductShowcaseView : IView
{
    event Action LoadProducts;
    event Action Serach;

    UserControl Instance { get; }
}