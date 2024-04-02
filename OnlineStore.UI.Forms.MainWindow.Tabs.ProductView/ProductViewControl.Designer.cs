namespace OnlineStore.UI.Forms.MainWindow.Tabs.ProductView;

public sealed partial class ProductViewControl
{
    private System.ComponentModel.IContainer _components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code
    private void InitializeComponent()
    {
        panel1 = new Panel();
        pictureBox1 = new PictureBox();
        label1 = new Label();
        label2 = new Label();
        button1 = new Button();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(button1);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(label1);
        panel1.Controls.Add(pictureBox1);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(364, 223);
        panel1.TabIndex = 0;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(364, 136);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // label1
        // 
        label1.Location = new Point(3, 139);
        label1.Name = "label1";
        label1.Size = new Size(90, 23);
        label1.TabIndex = 1;
        label1.Text = "label1";
        // 
        // label2
        // 
        label2.Location = new Point(3, 165);
        label2.Name = "label2";
        label2.Size = new Size(99, 23);
        label2.TabIndex = 2;
        label2.Text = "label2";
        // 
        // button1
        // 
        button1.Dock = DockStyle.Bottom;
        button1.Location = new Point(0, 191);
        button1.Name = "button1";
        button1.Size = new Size(364, 32);
        button1.TabIndex = 3;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // ProductViewControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(panel1);
        Name = "ProductViewControl";
        Size = new Size(364, 223);
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Label label2;
    private Label label1;
    private PictureBox pictureBox1;
    private Button button1;
}