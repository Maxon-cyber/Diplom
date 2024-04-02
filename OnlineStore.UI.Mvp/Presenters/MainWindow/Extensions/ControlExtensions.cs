namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Extensions;

internal static class ControlExtensions
{
    internal static void ThreadSafeAddition<TControl>(this TControl control, Action action)
        where TControl : Control
    {
        if (control.InvokeRequired)
            control.Invoke(action);
        else
            action();
    }
}