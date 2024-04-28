using OnlineStore.Domain.User;
using OnlineStore.Service;
using OnlineStore.Service.SqlServer.User;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Presenters.MainWindow;
using OnlineStore.UI.Mvp.Views.UserIdentification;
using System.Text;

namespace OnlineStore.UI.Mvp.Presenters.UserIdentification;

public sealed class AuthorizationPresenter : Presenter<IAuthorizationView>
{
    private readonly UserService _userService;

    public AuthorizationPresenter(IApplicationController controller, IAuthorizationView view, ServiceFacade service)
        : base(controller, view)
    {
        _userService = service.SqlServer.User;

        View.Authorization += Login;
        View.Registration += Registration;
    }

    private async void Login()
    {
        TextBox[] textBoxes = View.Instance.Controls.Find("panelMain", false)
                             .FirstOrDefault()
                             .Controls
                             .OfType<TextBox>()
                             .ToArray();

        UserEntity? user = await _userService.GetByAsync(new UserEntity
        {
            Login = textBoxes.FirstOrDefault(tb => tb.Name == "textBoxLogin").Text,
            Password = Encoding.UTF8.GetBytes(textBoxes.FirstOrDefault(tb => tb.Name == "textBoxPassword").Text.ToCharArray())
        });

        if (user == null)
        {
            MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show($"Добро Пожаловать, {user}!", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);

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