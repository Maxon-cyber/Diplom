using OnlineStore.Domain.Product;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs.Product;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs.Product;

public sealed class ProductPresenter : Presenter<IProductView, ProductEntity>
{
    private ProductEntity _product;

    private readonly PictureBox _productPhoto;
    private readonly Label _productName;
    private readonly Label _productPrice;

    public ProductPresenter(IProductView view, IApplicationController controller) 
        : base(view, controller)
    {
        Panel mainPanel = view.Instance.Controls.Find("panelMain", false).FirstOrDefault() as Panel;
        _productPhoto = mainPanel.Controls.Find("pictureBoxProductPhoto", false).FirstOrDefault() as PictureBox;
        _productName = mainPanel.Controls.Find("labelProductName", false).FirstOrDefault() as Label;
        _productPrice = mainPanel.Controls.Find("labelProductPrice", false).FirstOrDefault() as Label;
    }

    public override void Run(ProductEntity argument)
    {
        _product = argument;
    }

    internal UserControl Create()
    {
        using MemoryStream memoryStream = new MemoryStream(_product.Image);

        _productPhoto.Image = Image.FromStream(memoryStream);

        _productName.Text = _product.Name;
        _productPrice.Text = _product.Price.ToString();

        return View.Instance;
    }
}