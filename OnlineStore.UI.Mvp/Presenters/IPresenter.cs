namespace OnlineStore.UI.Mvp.Presenters;

public interface IPresenter
{
    void Run();

    void Run<TPresenter>(Action<TPresenter> action, TPresenter presenter);

    void Run(Control parentControl, UserControl childControl);
    
    void Run(Action action);
}

public interface IPresenter<in TArgument>
{
    void Run(TArgument argument);

    void RunAsChildComponent(TArgument argument, Control parentControl, UserControl childControl);
}