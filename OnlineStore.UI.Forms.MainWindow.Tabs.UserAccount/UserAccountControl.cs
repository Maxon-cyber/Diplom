using OnlineStore.UI.Mvp.Views;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Forms.MainWindow.Tabs.UserAccount;

public sealed partial class UserAccountControl : UserControl, IUserAccountView
{
    public UserAccountControl()
    {
        InitializeComponent();
    }

    public UserControl Instance => this;

    public new void Show()
        => base.Show();

    public void Close()
    {
        throw new NotImplementedException();
    }
}