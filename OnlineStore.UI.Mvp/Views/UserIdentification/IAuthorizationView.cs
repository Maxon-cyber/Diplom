namespace OnlineStore.UI.Mvp.Views.UserIdentification;

public interface IAuthorizationView : IView
{
    event Action Authorization;
    event Action Registration;

    Form Instance { get; }
}