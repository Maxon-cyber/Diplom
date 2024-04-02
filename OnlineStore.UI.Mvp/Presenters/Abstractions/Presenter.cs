using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Views;

namespace OnlineStore.UI.Mvp.Presenters.Abstractions;

public abstract class Presenter<TView> : IPresenter
    where TView : IView
{
    protected internal TView View { get; }

    protected IApplicationController Controller { get; }

    protected Presenter(IApplicationController controller, TView view)
        => (Controller, View) = (controller, view);

    public void Run()
        => View.Show();

    public void Run<TPresenter>(Action<TPresenter> action, TPresenter presenter)
    {
        action(presenter);
        View.Show();
    }

    public virtual void Run(Control parentControl, UserControl childControl)
    {
        childControl.BorderStyle = BorderStyle.None;
        childControl.Dock = DockStyle.Fill;

        parentControl.Controls.Add(childControl);
        parentControl.Tag = childControl;
        childControl.BringToFront();

        View.Show();
    }

    public void Run(Action action)
    {
        action();
        View.Show();
    }
}

public abstract class Presenter<TView, TArgument> : IPresenter<TArgument>
    where TView : IView
{
    protected TView View { get; }

    protected IApplicationController Controller { get; }

    protected Presenter(TView view, IApplicationController controller)
        => (View, Controller) = (view, controller);

    public abstract void Run(TArgument argument);

    public virtual void RunAsChildComponent(TArgument argument, Control parentControl, UserControl childControl)
    {
        childControl.BorderStyle = BorderStyle.None;
        childControl.Dock = DockStyle.Fill;
        parentControl.Controls.Add(childControl);
        parentControl.Tag = childControl;
        childControl.BringToFront();

        View.Show();
    }
}