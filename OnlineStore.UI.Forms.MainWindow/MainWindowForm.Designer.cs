namespace OnlineStore.UI.Forms.MainWindow;

public sealed partial class MainWindowForm
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
        panel1 = new Panel();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(button2);
        panel1.Location = new Point(2, 2);
        panel1.Name = "panel1";
        panel1.Size = new Size(209, 486);
        panel1.TabIndex = 0;
        // 
        // button2
        // 
        button2.Location = new Point(0, 89);
        button2.Name = "button2";
        button2.Size = new Size(209, 53);
        button2.TabIndex = 0;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new Point(0, 140);
        button3.Name = "button3";
        button3.Size = new Size(209, 53);
        button3.TabIndex = 1;
        button3.Text = "button3";
        button3.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new Point(0, 189);
        button4.Name = "button4";
        button4.Size = new Size(209, 53);
        button4.TabIndex = 2;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // MainWindowForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(895, 487);
        Controls.Add(panel1);
        Name = "MainWindowForm";
        Text = "MainWindowForm";
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }
    #endregion

    private Panel panel1;
    private Button button4;
    private Button button3;
    private Button button2;
}