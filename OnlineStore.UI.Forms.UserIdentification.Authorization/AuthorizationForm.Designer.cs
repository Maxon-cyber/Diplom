namespace OnlineStore.UI.Forms.UserIdentification.Authorization;

public sealed partial class AuthorizationForm
{
    private System.ComponentModel.IContainer _components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        buttonLogin = new Button();
        textBoxPassword = new TextBox();
        textBoxLogin = new TextBox();
        pictureBox1 = new PictureBox();
        buttonRegistration = new Button();
        errorProvider = new ErrorProvider(components);
        panelMain = new Panel();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        panelMain.SuspendLayout();
        SuspendLayout();
        // 
        // buttonLogin
        // 
        buttonLogin.Location = new Point(81, 307);
        buttonLogin.Name = "buttonLogin";
        buttonLogin.Size = new Size(100, 23);
        buttonLogin.TabIndex = 0;
        buttonLogin.Text = "Войти";
        buttonLogin.UseVisualStyleBackColor = true;
        buttonLogin.Click += BtnLogin_Click;
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(81, 247);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(100, 23);
        textBoxPassword.TabIndex = 1;
        textBoxPassword.Tag = "Пароль";
        // 
        // textBoxLogin
        // 
        textBoxLogin.Location = new Point(81, 199);
        textBoxLogin.Name = "textBoxLogin";
        textBoxLogin.Size = new Size(100, 23);
        textBoxLogin.TabIndex = 2;
        textBoxLogin.Tag = "Логин";
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(39, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(200, 148);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // buttonRegistration
        // 
        buttonRegistration.Location = new Point(69, 359);
        buttonRegistration.Name = "buttonRegistration";
        buttonRegistration.Size = new Size(128, 23);
        buttonRegistration.TabIndex = 4;
        buttonRegistration.Text = "Зарегистрироваться";
        buttonRegistration.UseVisualStyleBackColor = true;
        buttonRegistration.Click += BtnRegistration_Click;
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // panelMain
        // 
        panelMain.Controls.Add(pictureBox1);
        panelMain.Controls.Add(buttonRegistration);
        panelMain.Controls.Add(textBoxLogin);
        panelMain.Controls.Add(buttonLogin);
        panelMain.Controls.Add(textBoxPassword);
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new Point(0, 0);
        panelMain.Name = "panelMain";
        panelMain.Size = new Size(279, 463);
        panelMain.TabIndex = 5;
        // 
        // AuthorizationForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(279, 463);
        Controls.Add(panelMain);
        Name = "AuthorizationForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        panelMain.ResumeLayout(false);
        panelMain.PerformLayout();
        ResumeLayout(false);
    }
    #endregion

    private Button buttonLogin;
    private TextBox textBoxPassword;
    private TextBox textBoxLogin;
    private PictureBox pictureBox1;
    private Button buttonRegistration;
    private ErrorProvider errorProvider;
    private System.ComponentModel.IContainer components;
    private Panel panelMain;
}