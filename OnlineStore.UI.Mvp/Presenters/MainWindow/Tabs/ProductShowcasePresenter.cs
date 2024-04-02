using OnlineStore.Domain.Product;
using OnlineStore.Service;
using OnlineStore.Service.Product;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Presenters.MainWindow.Extensions;
using OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs.Product;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs;

public sealed class ProductShowcasePresenter : Presenter<IProductShowcaseView>
{
    private readonly IProductService _poductService;
    private readonly TableLayoutPanel _productShowcaseTLP;

    public ProductShowcasePresenter(ServiceFacade service, IProductShowcaseView view, IApplicationController controller)
        : base(controller, view)
    {
        _poductService = service.Product;
        _productShowcaseTLP = View.Instance.Controls.Find("tableLauoytproductShowcase", false).FirstOrDefault() as TableLayoutPanel;

        View.LoadProducts += LoadProducts;
        View.Serach += SeachProduct;
    }

    private async void LoadProducts()
    {
        ThreadPool.QueueUserWorkItem(async (_) =>
        {
            IEnumerable<ProductEntity> products = await _poductService.SelectAsync();

            ProductEntity[] productsArray = products.ToArray();

            int countOfProducts = products.Count();

            if (countOfProducts == 0)
                return;

            int columnTPL = _productShowcaseTLP.ColumnCount;
            int rowTPL = countOfProducts / columnTPL;
            _productShowcaseTLP.RowCount = rowTPL;

            _productShowcaseTLP.SuspendLayout();
            for (int index = 0; index < countOfProducts; index++)
            {
                int column = index % columnTPL;
                int row = index / columnTPL;

                Controller.Run<ProductPresenter, ProductEntity>(d =>
                {
                    _productShowcaseTLP.ThreadSafeAddition(() => _productShowcaseTLP.Controls.Add(d.Create(), column, row));
                });
            }
            _productShowcaseTLP.ResumeLayout();

            UpdateRowAndColumnStyles(columnTPL, rowTPL, _productShowcaseTLP.RowStyles, _productShowcaseTLP.ColumnStyles);
            _productShowcaseTLP.Invalidate();
        });
    }

    private void SeachProduct()
    {
        TextBox searchTextBox = View.Instance.Controls.Find("textBoxSearch", false).FirstOrDefault() as TextBox;
        if (string.IsNullOrWhiteSpace(searchTextBox.Text))
        {
            View.ShowMessage("Введите название товара");
            return;
        }

        Control? needControl = _productShowcaseTLP.Controls.Find($"{searchTextBox.Text}Panel", true).FirstOrDefault();

        if (needControl == null)
        {
            View.ShowMessage("Элемент не найден");
            return;
        }

        int desiredRow = _productShowcaseTLP.GetRow(needControl);
        int desiredColumn = _productShowcaseTLP.GetColumn(needControl);
        _productShowcaseTLP.ScrollControlIntoView(_productShowcaseTLP.GetControlFromPosition(desiredColumn, desiredRow));
        needControl.Select();
    }

    private void UpdateRowAndColumnStyles(int countOfRowTPL, int countOfColumnTPL, TableLayoutRowStyleCollection rowStyles, TableLayoutColumnStyleCollection columnStyles)
    {
        rowStyles.Clear();
        columnStyles.Clear();

        for (int rowIndex = 0; rowIndex < countOfRowTPL; rowIndex++)
            rowStyles.Add(new RowStyle() { Height = 100F, SizeType = SizeType.Percent });
        for (int columnIndex = 0; columnIndex < countOfColumnTPL; columnIndex++)
            columnStyles.Add(new ColumnStyle() { Width = 50F, SizeType = SizeType.Percent });
    }
}