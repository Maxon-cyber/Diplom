using OnlineStore.UI.Mvp.Common;
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

    public void ShowMessage(string message, MessageLevel messageLevel = MessageLevel.Information)
    {
        throw new NotImplementedException();
    }
}