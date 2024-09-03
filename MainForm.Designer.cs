namespace Sp00ksy
{
    partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Button buttonImageConverter;
        private Button buttonNetCheck;
        private Button buttonPingCheck;
        private Button btnOpenChat;
        private TableLayoutPanel tableLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonImageConverter = new Button();
            this.buttonNetCheck = new Button();
            this.buttonPingCheck = new Button();
            this.btnOpenChat = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // buttonImageConverter
            // 
            this.buttonImageConverter.BackColor = Color.FromArgb(40, 40, 40);
            this.buttonImageConverter.FlatStyle = FlatStyle.Flat;
            this.buttonImageConverter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.buttonImageConverter.ForeColor = Color.White;
            this.buttonImageConverter.Dock = DockStyle.Fill;
            this.buttonImageConverter.Location = new Point(3, 3);
            this.buttonImageConverter.Name = "buttonImageConverter";
            this.buttonImageConverter.Size = new Size(250, 34);
            this.buttonImageConverter.TabIndex = 0;
            this.buttonImageConverter.Text = "Image Converter";
            this.buttonImageConverter.UseVisualStyleBackColor = false;
            this.buttonImageConverter.Click += new EventHandler(this.ImageConverter_Click);

            // 
            // buttonNetCheck
            // 
            this.buttonNetCheck.BackColor = Color.FromArgb(40, 40, 40);
            this.buttonNetCheck.FlatStyle = FlatStyle.Flat;
            this.buttonNetCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.buttonNetCheck.ForeColor = Color.White;
            this.buttonNetCheck.Dock = DockStyle.Fill;
            this.buttonNetCheck.Location = new Point(259, 3);
            this.buttonNetCheck.Name = "buttonNetCheck";
            this.buttonNetCheck.Size = new Size(250, 34);
            this.buttonNetCheck.TabIndex = 1;
            this.buttonNetCheck.Text = "Net Check";
            this.buttonNetCheck.UseVisualStyleBackColor = false;
            this.buttonNetCheck.Click += new EventHandler(this.NetCheck_Click);

            // 
            // buttonPingCheck
            // 
            this.buttonPingCheck.BackColor = Color.FromArgb(40, 40, 40);
            this.buttonPingCheck.FlatStyle = FlatStyle.Flat;
            this.buttonPingCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.buttonPingCheck.ForeColor = Color.White;
            this.buttonPingCheck.Dock = DockStyle.Fill;
            this.buttonPingCheck.Location = new Point(515, 3);
            this.buttonPingCheck.Name = "buttonPingCheck";
            this.buttonPingCheck.Size = new Size(250, 34);
            this.buttonPingCheck.TabIndex = 2;
            this.buttonPingCheck.Text = "Check Ping";
            this.buttonPingCheck.UseVisualStyleBackColor = false;
            this.buttonPingCheck.Click += new EventHandler(this.PingCheck_Click);

            // 
            // btnOpenChat
            // 
            this.btnOpenChat.BackColor = Color.FromArgb(40, 40, 40);
            this.btnOpenChat.FlatStyle = FlatStyle.Flat;
            this.btnOpenChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnOpenChat.ForeColor = Color.White;
            this.btnOpenChat.Dock = DockStyle.Fill;
            this.btnOpenChat.Location = new Point(771, 3);
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new Size(251, 34);
            this.btnOpenChat.TabIndex = 3;
            this.btnOpenChat.Text = "Chat";
            this.btnOpenChat.UseVisualStyleBackColor = false;
            this.btnOpenChat.Click += new EventHandler(this.btnOpenChat_Click);

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = Color.Black;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonImageConverter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonNetCheck, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPingCheck, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenChat, 3, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Top;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new Size(1025, 40);
            this.tableLayoutPanel1.TabIndex = 0;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(1025, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Sp00ksy - Main";
            this.Load += new EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

    }
}
