using OnlineStore.UI.Mvp.Common;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Forms.MainWindow.Tabs.ProductShowcase;

public sealed partial class ProductShowcaseControl : UserControl, IProductShowcaseView
{
    public event Action LoadProducts;

    public UserControl Instance => this;

    public ProductShowcaseControl()
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

    private void ProductShowcaseContorl_Load(object sender, EventArgs e)
        => LoadProducts?.Invoke();
}