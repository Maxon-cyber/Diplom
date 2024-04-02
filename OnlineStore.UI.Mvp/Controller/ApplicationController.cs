using OnlineStore.UI.Mvp.Configuration;
using OnlineStore.UI.Mvp.DI;
using OnlineStore.UI.Mvp.Presenters;
using System;

namespace OnlineStore.UI.Mvp.Controller;

public sealed class ApplicationController(IDIContainer container, IAppConfiguration configuration) : IApplicationController
{
    public IDIContainer Container { get; } = container;

    public IAppConfiguration Configuration { get; } = configuration;

    public void Run<TPresenter>()
        where TPresenter : class, IPresenter
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.Run();
    }

    public void Run<TPresenter>(Action<TPresenter> action)
         where TPresenter : class, IPresenter
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.Run(action, presenter);
    }

    public void Run<TPresenter, TArgumnent>(TArgumnent argument)
        where TPresenter : class, IPresenter<TArgumnent>
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.Run(argument);
    }

    public void Run<TPresenter>(Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.Run(parentControl, childControl);
    }

    public void Run<TPresenter, TArgument>(TArgument argument, Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter<TArgument>
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.RunAsChildComponent(argument, parentControl, childControl);
    }

    public void Run<TPresenter>(Action action)
        where TPresenter : class, IPresenter
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.Run(action);
    }

    public void RunAsChildControl<TPresenter, TArgument>(TArgument argument, Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter<TArgument>
    {
        TPresenter presenter = Container.Resolve<TPresenter>();
        presenter.RunAsChildComponent(argument, parentControl, childControl);
    }

    public void RunAsChildControl<TPresenter>(Control parentControl, UserControl childControl)
        where TPresenter : class, IPresenter
    {
        Run<TPresenter>(parentControl, childControl);
    }
}