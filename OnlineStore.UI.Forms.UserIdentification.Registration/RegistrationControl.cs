using OnlineStore.UI.Mvp.Common;
using OnlineStore.UI.Mvp.Views.UserIdentification;
using static OnlineStore.Domain.User.UserParameters;

namespace OnlineStore.UI.Forms.UserIdentification.Registration;

public sealed partial class RegistrationControl : UserControl, IRegistrationView
{
    public event Action Registration;

    public event Action ReturnToAuthorization;

    public TextBox[] UserInput { get; }

    public UserControl Instance => this;

    public RegistrationControl()
    {
        InitializeComponent();

        UserInput = Controls.OfType<TextBox>().ToArray();
    }

    public new void Show()
        => base.Show();

    public void Close()
        => ((Form)TopLevelControl).Close();

    public void ShowMessage(string message, MessageLevel messageLevel = MessageLevel.Information)
    {
        throw new NotImplementedException();
    }

    private void BtnRegistration_Click(object sender, EventArgs e)
    {
        IEnumerable<TextBox> emptyTextBoxes = UserInput.Where(tb => string.IsNullOrWhiteSpace(tb.Text));

        if (emptyTextBoxes.Any())
        {
            foreach (TextBox textBox in emptyTextBoxes)
                errorProvider.SetError(textBox, $"Введите значение{textBox.Name}");

            return;
        }

        if (!Login.IsValid())
        {
            errorProvider.SetError(textBoxLogin, "Не валидные данные");
            return;
        }
        else if (Password.IsValid())
        {
            errorProvider.SetError(textBoxPassword, "Не валидные данные");
            return;
        }

        Registration?.Invoke();
    }

    private void BtnReturnToAuthorization(object sender, EventArgs e)
        => ReturnToAuthorization?.Invoke();
}