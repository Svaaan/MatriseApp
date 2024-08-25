namespace Sp00ksy
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(335, 34);
            button1.TabIndex = 0;
            button1.Text = "Image Converter";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ImageConverter_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Dock = DockStyle.Fill;
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(344, 3);
            button2.Name = "button2";
            button2.Size = new Size(335, 34);
            button2.TabIndex = 1;
            button2.Text = "Net check";
            button2.UseVisualStyleBackColor = false;
            button2.Click += NetCheck_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Dock = DockStyle.Fill;
            button3.ForeColor = Color.White;
            button3.Location = new Point(685, 3);
            button3.Name = "button3";
            button3.Size = new Size(337, 34);
            button3.TabIndex = 2;
            button3.Text = "Check ping";
            button3.UseVisualStyleBackColor = false;
            button3.Click += PingCheck_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1025, 40);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(tableLayoutPanel1);
            Name = "sp00ksy";
            Text = "sp00ksy";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button2;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel1;

    }
}
