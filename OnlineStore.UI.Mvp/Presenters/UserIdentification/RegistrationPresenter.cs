using OnlineStore.Domain.User;
using OnlineStore.Service;
using OnlineStore.Service.Common;
using OnlineStore.Service.SqlServer.User;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.UserIdentification;
using System.Text;

namespace OnlineStore.UI.Mvp.Presenters.UserIdentification;

public sealed class RegistrationPresenter : Presenter<IRegistrationView>
{
    private readonly UserService _userService;
    private readonly TextBox[] _textBoxes;

    public RegistrationPresenter(ServiceFacade service, IRegistrationView view, IApplicationController controller)
        : base(controller, view)
    {
        _userService = service.SqlServer.User;

        _textBoxes = View.Instance.Controls.OfType<TextBox>().ToArray();

        View.Registration += Registration;
        View.ReturnToAuthorization += ReturnToAuthorization;
    }

    private async void Registration()
    {
        bool isAdded = await _userService.UpdateAsync(TypeOfEntityUpdateCommand.Insert, new UserEntity()
        {
            Name = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxName").Text,
            SecondName = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxSecondName").Text,
            Patronymic = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxPatronymic").Text,
            Gender = Enum.Parse<Gender>(View.Instance.Controls.Find("panelGender", true).FirstOrDefault().Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked == true).Tag.ToString()),
            Age = Convert.ToUInt32(_textBoxes.FirstOrDefault(tb => tb.Name == "textBoxAge").Text),
            Location = new Location()
            {
                HouseNumber = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxHouseNumber").Text,
                Street = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxStreet").Text,
                City = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxCity").Text,
                Region = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxRegion").Text,
                Country = _textBoxes.FirstOrDefault(tb => tb.Name == "textBoxCountry").Text,
            },
            Login =_textBoxes.FirstOrDefault(tb => tb.Name == "textBoxLogin").Text,
            Password = Encoding.UTF8.GetBytes(_textBoxes.FirstOrDefault(tb => tb.Name == "textBoxPassword").Text.ToCharArray()),
            Role = UserParameters.DEFAULT_ROLE
        });

        if (!isAdded)
            MessageBox.Show("Пользователь с таким логином уже зарегистрирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        else
            MessageBox.Show("Вы успешно зарегистрированы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ReturnToAuthorization()
        => Controller.Run<AuthorizationPresenter>(presenter =>
        {
            Panel? main = presenter.View.Instance.Controls.Find("panelMain", true).FirstOrDefault() as Panel;

            main?.Controls.Remove(main.Controls.Find("RegistrationControl", true).FirstOrDefault());
        });
} 