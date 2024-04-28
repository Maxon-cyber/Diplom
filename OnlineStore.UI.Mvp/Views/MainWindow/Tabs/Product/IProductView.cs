using OnlineStore.Domain.Product;

namespace OnlineStore.UI.Mvp.Views.MainWindow.Tabs.Product;

public interface IProductView : IView
{
    event Action Add;

    event Action Remove;

    UserControl Instance { get; }
}