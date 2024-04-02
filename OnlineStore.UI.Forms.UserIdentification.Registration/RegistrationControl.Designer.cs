namespace OnlineStore.UI.Forms.UserIdentification.Registration;

public sealed partial class RegistrationControl
{
    private System.ComponentModel.IContainer _components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        textBoxLogin = new TextBox();
        errorProvider = new ErrorProvider(components);
        textBoxPassword = new TextBox();
        buttonReturnToAuthorization = new Button();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // textBoxLogin
        // 
        textBoxLogin.Location = new Point(63, 221);
        textBoxLogin.Name = "textBoxLogin";
        textBoxLogin.Size = new Size(100, 23);
        textBoxLogin.TabIndex = 0;
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(63, 276);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(100, 23);
        textBoxPassword.TabIndex = 1;
        // 
        // buttonReturnToAuthorization
        // 
        buttonReturnToAuthorization.Location = new Point(63, 337);
        buttonReturnToAuthorization.Name = "buttonReturnToAuthorization";
        buttonReturnToAuthorization.Size = new Size(100, 23);
        buttonReturnToAuthorization.TabIndex = 2;
        buttonReturnToAuthorization.Text = "Войти";
        buttonReturnToAuthorization.UseVisualStyleBackColor = true;
        buttonReturnToAuthorization.Click += BtnReturnToAuthorization;
        // 
        // RegistrationControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonReturnToAuthorization);
        Controls.Add(textBoxPassword);
        Controls.Add(textBoxLogin);
        Name = "RegistrationControl";
        Size = new Size(264, 494);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private TextBox textBoxLogin;
    private ErrorProvider errorProvider;
    private System.ComponentModel.IContainer components;
    private TextBox textBoxPassword;
    private Button buttonReturnToAuthorization;
}