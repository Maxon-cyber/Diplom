using OnlineStore.UI.Mvp.Views;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs.Product;

namespace OnlineStore.UI.Forms.MainWindow.Tabs.ProductView;

public sealed partial class ProductViewControl : UserControl, IProductView
{
    public ProductViewControl()
    {
        InitializeComponent();
    }

    public UserControl Instance => throw new NotImplementedException();

    public event Action Add;
    public event Action Remove;

    public void Close()
    {
        throw new NotImplementedException();
    }
}