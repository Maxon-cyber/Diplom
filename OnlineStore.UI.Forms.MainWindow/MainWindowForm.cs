using OnlineStore.UI.Mvp.Views.MainWindow;

namespace OnlineStore.UI.Forms.MainWindow;

public sealed partial class MainWindowForm : Form, IMainWindowView
{
    private readonly ApplicationContext _context;

    public event Action UserAccount;
    public event Action ProductShowcase;
    public event Action ShoppingCart;

    public Form Instance => this;

    public MainWindowForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();
    }

    public new void Show()
    {
        _context.MainForm = this;
        base.Show();
    }

    private void BtnOpenUserAccount_Click(object sender, EventArgs e)
        => UserAccount?.Invoke();

    private void BtnOpenProductShowcase_Click(object sender, EventArgs e)
        => ProductShowcase?.Invoke();

    private void BtnOpenShoppingCart_Click(object sender, EventArgs e)
        => ShoppingCart?.Invoke();
}