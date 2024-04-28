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
        textBoxSearch = new TextBox();
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
        // textBoxSearch
        // 
        textBoxSearch.Location = new Point(17, 51);
        textBoxSearch.Name = "textBoxSearch";
        textBoxSearch.Size = new Size(346, 23);
        textBoxSearch.TabIndex = 1;
        // 
        // button1
        // 
        button1.Location = new Point(413, 51);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += BtnSearch_Click;
        // 
        // ProductShowcaseControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(button1);
        Controls.Add(textBoxSearch);
        Controls.Add(tableLayoutPanel1);
        Name = "ProductShowcaseControl";
        Size = new Size(682, 415);
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TextBox textBoxSearch;
    private Button button1;
}