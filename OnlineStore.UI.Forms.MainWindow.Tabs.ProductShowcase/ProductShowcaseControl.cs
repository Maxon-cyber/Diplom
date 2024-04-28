using OnlineStore.UI.Mvp.Views;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Forms.MainWindow.Tabs.ProductShowcase;

public sealed partial class ProductShowcaseControl : UserControl, IProductShowcaseView
{
    public event Action LoadProducts;
    public event Action Search;

    public UserControl Instance => this;

    public ProductShowcaseControl()
    {
        InitializeComponent();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    private void ProductShowcaseContorl_Load(object sender, EventArgs e)
        => LoadProducts?.Invoke();

    private void BtnSearch_Click(object sender, EventArgs e)
        => Search?.Invoke();
}