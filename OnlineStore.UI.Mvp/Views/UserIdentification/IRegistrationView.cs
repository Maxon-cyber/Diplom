namespace OnlineStore.UI.Mvp.Views.UserIdentification;

public interface IRegistrationView : IView
{
    event Action Registration;

    event Action ReturnToAuthorization;

    UserControl Instance { get; }
}