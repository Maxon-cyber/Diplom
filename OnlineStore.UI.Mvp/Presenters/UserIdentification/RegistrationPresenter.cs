using OnlineStore.Domain.Common;
using OnlineStore.Domain.User;
using OnlineStore.Service;
using OnlineStore.Service.Common;
using OnlineStore.Service.User;
using OnlineStore.UI.Mvp.Common;
using OnlineStore.UI.Mvp.Controller;
using OnlineStore.UI.Mvp.Presenters.Abstractions;
using OnlineStore.UI.Mvp.Views.UserIdentification;

namespace OnlineStore.UI.Mvp.Presenters.UserIdentification;

public sealed class RegistrationPresenter : Presenter<IRegistrationView>
{
    private readonly IUserService _userService;

    public RegistrationPresenter(ServiceFacade service, IRegistrationView view, IApplicationController controller)
        : base(controller, view)
    {
        _userService = service.User;

        View.Registration += () => Registration(View.UserInput);
        View.ReturnToAuthorization += ReturnToAuthorization;
    }

    private async void Registration(TextBox[] userData)
    {
        bool isAdded = await _userService.UpdateAsync(TypeOfEntityUpdateCommand.Insert, new UserEntity()
        {
            Id = ID.Create(),
            Name = userData.FirstOrDefault(tb => tb.Name == "textBoxName").Text,
            SecondName = userData.FirstOrDefault(tb => tb.Name == "textBoxSecondName").Text,
            Patronymic = userData.FirstOrDefault(tb => tb.Name == "textBoxPatronymic").Text,
            Gender = Enum.Parse<Gender>(userData.FirstOrDefault(tb => tb.Name == "textBoxGender").Text),
            Age = Convert.ToUInt32(userData.FirstOrDefault(tb => tb.Name == "textBoxAge").Text),
            Location = new Location()
            {
                HouseNumber = userData.FirstOrDefault(tb => tb.Name == "textBoxHouseNumber").Text,
                Street = userData.FirstOrDefault(tb => tb.Name == "textBoxStreet").Text,
                City = userData.FirstOrDefault(tb => tb.Name == "textBoxCity").Text,
                Region = userData.FirstOrDefault(tb => tb.Name == "textBoxRegion").Text,
                Country = userData.FirstOrDefault(tb => tb.Name == "textBoxCountry").Text,
            },
            Login = userData.FirstOrDefault(tb => tb.Name == "textBoxLogin").Text,
            Password = userData.FirstOrDefault(tb => tb.Name == "textBoxPassword").Text,
            Role = UserParameters.DEFAULT_ROLE,
            TimeCreated = DateTime.Now,
            LastAccesTime = DateTime.Now,
            LastUpdateTime = DateTime.Now
        });

        if (!isAdded)
            View.ShowMessage("Пользователь с таким логином уже зарегистрирован", MessageLevel.Error);
        else
            View.ShowMessage("Пользователь с таким логином уже зарегстрирован");
    }

    private void ReturnToAuthorization()
        => Controller.Run<AuthorizationPresenter>(presenter =>
        {
            Panel main = presenter.View.Instance.Controls.Find("panelMain", true).FirstOrDefault() as Panel;

            main.Controls.Remove(main.Controls.Find("RegistrationControl", true).FirstOrDefault());
        });
}