using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs.Product;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs.Product;

public sealed class ProductPresenter : Presenter<IProductView>
{
    public ProductPresenter(IProductView view, IApplicationController controller)
        : base(controller, view)
    { }
}