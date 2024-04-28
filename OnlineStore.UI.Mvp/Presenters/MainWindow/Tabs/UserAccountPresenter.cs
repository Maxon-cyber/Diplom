using OnlineStore.Domain.User;
using OnlineStore.Service;
using OnlineStore.Service.SqlServer.User;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.MainWindow.Tabs;

namespace OnlineStore.UI.Mvp.Presenters.MainWindow.Tabs;

public sealed class UserAccountPresenter : Presenter<IUserAccountView, UserEntity>
{
    private UserEntity _user;
    private readonly IUserService _userService;

    public UserAccountPresenter(ServiceFacade service, IUserAccountView view, IApplicationController controller)
        : base(view, controller)
    {
        _userService = service.SqlServer.User;
    }

    public override void Run(UserEntity argument)
    {
        _user = argument;
        View.Show();
    }

    private void LoadUserData()
    {

    }
}