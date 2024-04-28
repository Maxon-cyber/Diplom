using OnlineStore.UI.Mvp.Configuration;
using OnlineStore.UI.Mvp.DI;
using OnlineStore.UI.Mvp.Presenters;

namespace OnlineStore.UI.Mvp.Controller;

public interface IApplicationController
{
    public IIoCContainer Container { get; }

    public IAppConfiguration Configuration { get; }

    void Run<TPresenter>()
        where TPresenter : class, IPresenter;

    void Run<TPresenter>(Action<TPresenter> action)
        where TPresenter : class, IPresenter;

    void Run<TPresenter, TArgument>(TArgument argumnent)
        where TPresenter : class, IPresenter<TArgument>;

    void Run<TPresenter>(Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter;

    void Run<TPresenter>(Action action)
        where TPresenter : class, IPresenter;

    void Run<TPresenter, TArgument>(TArgument argument, Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter<TArgument>;

    void Run<TPresenter, TArgument>(Action<TPresenter> action)
        where TPresenter : class, IPresenter<TArgument>;

    void RunAsChildControl<TPresenter>(Control parentControl, UserControl childControl)
       where TPresenter : class, IPresenter;

    void RunAsChildControl<TPresenter, TArgument>(TArgument argument, Control parentControl, UserControl childControl)
       where TPresenter : class, IPresenter<TArgument>;
}