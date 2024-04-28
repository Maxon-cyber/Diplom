using OnlineStore.UI.Mvp.Views.UserIdentification;

namespace OnlineStore.UI.Forms.UserIdentification.Registration;

public sealed partial class RegistrationControl : UserControl, IRegistrationView
{
    public event Action Registration;

    public event Action ReturnToAuthorization;

    private readonly TextBox[] _userInput;

    public UserControl Instance => this;

    public RegistrationControl()
    {
        InitializeComponent();

        _userInput = Controls.OfType<TextBox>().ToArray();
    }

    public new void Show()
        => base.Show();

    public void Close()
        => ((Form)TopLevelControl).Close();

    private void BtnRegistration_Click(object sender, EventArgs e)
    {
        errorProvider.Clear();

        IEnumerable<TextBox> emptyTextBoxes = _userInput.Where(tb => string.IsNullOrWhiteSpace(tb.Text));

        if (emptyTextBoxes.Any())
        {
            foreach (TextBox textBox in emptyTextBoxes)
                errorProvider.SetError(textBox, $"Введите значение{textBox.Name}");

            return;
        }

        Registration?.Invoke();
    }

    private void BtnReturnToAuthorization(object sender, EventArgs e)
        => ReturnToAuthorization?.Invoke();
}