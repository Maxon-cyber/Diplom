namespace OnlineStore.UI.Forms.MainWindow.Tabs.ProductShowcase;

public sealed partial class ProductShowcaseControl
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
        tableLayoutPanel1 = new TableLayoutPanel();
        textBox1 = new TextBox();
        button1 = new Button();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Dock = DockStyle.Bottom;
        tableLayoutPanel1.Location = new Point(0, 151);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new Size(682, 264);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(21, 41);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(346, 23);
        textBox1.TabIndex = 1;
        // 
        // button1
        // 
        button1.Location = new Point(418, 41);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // ProductShowcaseControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(button1);
        Controls.Add(textBox1);
        Controls.Add(tableLayoutPanel1);
        Name = "ProductShowcaseControl";
        Size = new Size(682, 415);
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TextBox textBox1;
    private Button button1;
}