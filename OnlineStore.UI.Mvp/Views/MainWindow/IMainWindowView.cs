namespace OnlineStore.UI.Mvp.Views.MainWindow;

public interface IMainWindowView : IView
{
    event Action UserAccount;
    event Action ProductShowcase;
    event Action ShoppingCart;

    Form Instance { get; }
}