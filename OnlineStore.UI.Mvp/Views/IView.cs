using OnlineStore.UI.Mvp.Common;

namespace OnlineStore.UI.Mvp.Views;

public interface IView
{
    void Show();

    void ShowMessage(string message, MessageLevel messageLevel = MessageLevel.Information);

    void Close();
}