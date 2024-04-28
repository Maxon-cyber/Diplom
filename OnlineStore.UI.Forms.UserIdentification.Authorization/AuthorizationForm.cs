using OnlineStore.UI.Mvp.Views.UserIdentification;

namespace OnlineStore.UI.Forms.UserIdentification.Authorization;

public sealed partial class AuthorizationForm : Form, IAuthorizationView
{
    private bool isRunable = false;

    private readonly TextBox[] _textBoxes;
    private readonly ApplicationContext _context;

    public event Action Authorization;
    public event Action Registration;

    public Form Instance => this;

    public AuthorizationForm(ApplicationContext context)
    {
        InitializeComponent();

        _context = context;

        _textBoxes = Controls.Find("panelMain", false)
                             .FirstOrDefault()
                             .Controls
                             .OfType<TextBox>()
                             .ToArray();
    }

    public new void Show()
    {
        if (!isRunable)
        {
            isRunable = true;

            _context.MainForm = this;
            Application.Run(_context);
        }
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        IEnumerable<TextBox> emptyTextBoxes = _textBoxes.Where(tb => string.IsNullOrWhiteSpace(tb.Text));

        if (emptyTextBoxes.Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
        {
            foreach (TextBox textBox in emptyTextBoxes)
                errorProvider.SetError(textBox, $"¬ведите значение {textBox.Tag}");
            return;
        }

        Authorization?.Invoke();
    }

    private void BtnRegistration_Click(object sender, EventArgs e)
        => Registration?.Invoke();
}