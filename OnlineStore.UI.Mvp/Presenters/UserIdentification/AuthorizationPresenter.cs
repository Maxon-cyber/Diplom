using OnlineStore.Domain.User;
using OnlineStore.Service;
using OnlineStore.Service.User;
using OnlineStore.UI.Mvp.Common;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Presenters.MainWindow;
using OnlineStore.UI.Mvp.Views.UserIdentification;

namespace OnlineStore.UI.Mvp.Presenters.UserIdentification;

public sealed class AuthorizationPresenter : Presenter<IAuthorizationView>
{
    private readonly IUserService _userService;

    public AuthorizationPresenter(IApplicationController controller, IAuthorizationView view, ServiceFacade service)
        : base(controller, view)
    {
        _userService = service.User;

        View.Authorization += Login;
        View.Registration += Registration;
    }

    private async void Login()
    {
        TextBox[] textBoxes = View.Instance.Controls.OfType<TextBox>().ToArray();

        UserEntity? user = await _userService.GetByAsync(new UserEntity
        {
            Login = textBoxes.FirstOrDefault(tb => tb.Name == "textBoxLogin").Text,
            Password = textBoxes.FirstOrDefault(tb => tb.Name == "textBoxPassword").Text
        });

        if (user == null)
        {
            View.ShowMessage("Неправильный логин или пароль", MessageLevel.Error);
            return;
        }

        View.ShowMessage($"Добро Пожаловать, {user}!");

        switch (user.Role)
        {
            case Role.User:
                Controller.Run<MainWindowPresenter, UserEntity>(user);
                View.Close();
                break;
            case Role.Admin:
                break;
        }
    }

    private void Registration()
        => Controller.Run<RegistrationPresenter>(presenter =>
            {
                Panel panel = View.Instance.Controls.Find("panelMain", false)
                                            .FirstOrDefault() as Panel ?? throw new NullReferenceException();

                UserControl registrationControl = presenter.View.Instance;

                registrationControl.BorderStyle = BorderStyle.None;
                registrationControl.Dock = DockStyle.Fill;

                panel.Controls.Add(registrationControl);
                panel.Tag = registrationControl;

                registrationControl.BringToFront();
            });
}