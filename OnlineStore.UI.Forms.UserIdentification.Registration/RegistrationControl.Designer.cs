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
        textBoxHouseNumber = new TextBox();
        errorProvider = new ErrorProvider(components);
        textBoxStreet = new TextBox();
        buttonReturnToAuthorization = new Button();
        buttonRegistration = new Button();
        textBoxName = new TextBox();
        textBoxSecondName = new TextBox();
        textBoxPatronymic = new TextBox();
        textBoxCity = new TextBox();
        textBoxAge = new TextBox();
        textBoxLogin = new TextBox();
        textBoxPassword = new TextBox();
        textBoxRegion = new TextBox();
        textBoxCountry = new TextBox();
        radioButtonMan = new RadioButton();
        panelGender = new Panel();
        radioButtonWoman = new RadioButton();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        panelGender.SuspendLayout();
        SuspendLayout();
        // 
        // textBoxHouseNumber
        // 
        textBoxHouseNumber.Location = new Point(176, 28);
        textBoxHouseNumber.Name = "textBoxHouseNumber";
        textBoxHouseNumber.PlaceholderText = "Номер дома";
        textBoxHouseNumber.Size = new Size(100, 23);
        textBoxHouseNumber.TabIndex = 0;
        // 
        // errorProvider
        // 
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        // 
        // textBoxStreet
        // 
        textBoxStreet.Location = new Point(176, 77);
        textBoxStreet.Name = "textBoxStreet";
        textBoxStreet.PlaceholderText = "Улица";
        textBoxStreet.Size = new Size(100, 23);
        textBoxStreet.TabIndex = 1;
        // 
        // buttonReturnToAuthorization
        // 
        buttonReturnToAuthorization.Location = new Point(88, 407);
        buttonReturnToAuthorization.Name = "buttonReturnToAuthorization";
        buttonReturnToAuthorization.Size = new Size(125, 42);
        buttonReturnToAuthorization.TabIndex = 2;
        buttonReturnToAuthorization.Text = "Вернуться на форму входа";
        buttonReturnToAuthorization.UseVisualStyleBackColor = true;
        buttonReturnToAuthorization.Click += BtnReturnToAuthorization;
        // 
        // buttonRegistration
        // 
        buttonRegistration.Location = new Point(100, 362);
        buttonRegistration.Name = "buttonRegistration";
        buttonRegistration.Size = new Size(98, 23);
        buttonRegistration.TabIndex = 3;
        buttonRegistration.Text = "Регистрация";
        buttonRegistration.UseVisualStyleBackColor = true;
        buttonRegistration.Click += BtnRegistration_Click;
        // 
        // textBoxName
        // 
        textBoxName.Location = new Point(18, 28);
        textBoxName.Name = "textBoxName";
        textBoxName.PlaceholderText = "Имя";
        textBoxName.Size = new Size(100, 23);
        textBoxName.TabIndex = 4;
        // 
        // textBoxSecondName
        // 
        textBoxSecondName.Location = new Point(18, 77);
        textBoxSecondName.Name = "textBoxSecondName";
        textBoxSecondName.PlaceholderText = "Фамилия";
        textBoxSecondName.Size = new Size(100, 23);
        textBoxSecondName.TabIndex = 5;
        // 
        // textBoxPatronymic
        // 
        textBoxPatronymic.Location = new Point(18, 127);
        textBoxPatronymic.Name = "textBoxPatronymic";
        textBoxPatronymic.PlaceholderText = "Отчество";
        textBoxPatronymic.Size = new Size(100, 23);
        textBoxPatronymic.TabIndex = 6;
        // 
        // textBoxCity
        // 
        textBoxCity.Location = new Point(176, 127);
        textBoxCity.Name = "textBoxCity";
        textBoxCity.PlaceholderText = "Город";
        textBoxCity.Size = new Size(100, 23);
        textBoxCity.TabIndex = 7;
        // 
        // textBoxAge
        // 
        textBoxAge.Location = new Point(18, 175);
        textBoxAge.Name = "textBoxAge";
        textBoxAge.PlaceholderText = "Возраст";
        textBoxAge.Size = new Size(100, 23);
        textBoxAge.TabIndex = 9;
        // 
        // textBoxLogin
        // 
        textBoxLogin.Location = new Point(21, 294);
        textBoxLogin.Name = "textBoxLogin";
        textBoxLogin.PlaceholderText = "Логин";
        textBoxLogin.Size = new Size(100, 23);
        textBoxLogin.TabIndex = 10;
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(176, 294);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.PasswordChar = '*';
        textBoxPassword.PlaceholderText = "Пароль";
        textBoxPassword.Size = new Size(100, 23);
        textBoxPassword.TabIndex = 11;
        // 
        // textBoxRegion
        // 
        textBoxRegion.Location = new Point(176, 175);
        textBoxRegion.Name = "textBoxRegion";
        textBoxRegion.PlaceholderText = "Регион";
        textBoxRegion.Size = new Size(100, 23);
        textBoxRegion.TabIndex = 12;
        // 
        // textBoxCountry
        // 
        textBoxCountry.Location = new Point(176, 225);
        textBoxCountry.Name = "textBoxCountry";
        textBoxCountry.PlaceholderText = "Страна";
        textBoxCountry.Size = new Size(100, 23);
        textBoxCountry.TabIndex = 13;
        // 
        // radioButtonMan
        // 
        radioButtonMan.AutoSize = true;
        radioButtonMan.Location = new Point(3, 3);
        radioButtonMan.Name = "radioButtonMan";
        radioButtonMan.Size = new Size(54, 19);
        radioButtonMan.TabIndex = 14;
        radioButtonMan.TabStop = true;
        radioButtonMan.Tag = "Man";
        radioButtonMan.Text = "Муж.";
        radioButtonMan.UseVisualStyleBackColor = true;
        // 
        // panelGender
        // 
        panelGender.Controls.Add(radioButtonWoman);
        panelGender.Controls.Add(radioButtonMan);
        panelGender.Location = new Point(18, 215);
        panelGender.Name = "panelGender";
        panelGender.Size = new Size(118, 52);
        panelGender.TabIndex = 15;
        // 
        // radioButtonWoman
        // 
        radioButtonWoman.AutoSize = true;
        radioButtonWoman.Location = new Point(5, 28);
        radioButtonWoman.Name = "radioButtonWoman";
        radioButtonWoman.Size = new Size(52, 19);
        radioButtonWoman.TabIndex = 15;
        radioButtonWoman.TabStop = true;
        radioButtonWoman.Tag = "Woman";
        radioButtonWoman.Text = "Жен.";
        radioButtonWoman.UseVisualStyleBackColor = true;
        // 
        // RegistrationControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panelGender);
        Controls.Add(textBoxCountry);
        Controls.Add(textBoxRegion);
        Controls.Add(textBoxPassword);
        Controls.Add(textBoxLogin);
        Controls.Add(textBoxAge);
        Controls.Add(textBoxCity);
        Controls.Add(textBoxPatronymic);
        Controls.Add(textBoxSecondName);
        Controls.Add(textBoxStreet);
        Controls.Add(textBoxHouseNumber);
        Controls.Add(textBoxName);
        Controls.Add(buttonRegistration);
        Controls.Add(buttonReturnToAuthorization);
        Name = "RegistrationControl";
        Size = new Size(316, 494);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        panelGender.ResumeLayout(false);
        panelGender.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private TextBox textBoxHouseNumber;
    private ErrorProvider errorProvider;
    private System.ComponentModel.IContainer components;
    private TextBox textBoxStreet;
    private Button buttonReturnToAuthorization;
    private Button buttonRegistration;
    private TextBox textBoxSecondName;
    private TextBox textBoxName;
    private TextBox textBoxPassword;
    private TextBox textBoxLogin;
    private TextBox textBoxAge;
    private TextBox textBoxCity;
    private TextBox textBoxPatronymic;
    private TextBox textBoxCountry;
    private TextBox textBoxRegion;
    private Panel panelGender;
    private RadioButton radioButtonWoman;
    private RadioButton radioButtonMan;
}