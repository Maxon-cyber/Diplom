using System.Reflection;

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

    internal static TInstance Copy<TInstance>(this TInstance copyControl, string name = null)
        where TInstance : Control
    {
        TInstance instance = Activator.CreateInstance<TInstance>();

        Type copyControlType = copyControl.GetType();
        PropertyInfo[] info = copyControlType.GetProperties();
        
        copyControlType.InvokeMember("", BindingFlags.CreateInstance, null, copyControl, null);
        
        foreach (PropertyInfo pi in info)
            if ((pi.CanWrite) && !(pi.Name == "WindowTarget") && !(pi.Name == "Capture"))
                pi.SetValue(instance, pi.GetValue(copyControl, null), null);
        
        if (name != null)
            instance.Name = name;
        
        return instance;
    }
}