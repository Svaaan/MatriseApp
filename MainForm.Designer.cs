namespace Matrise
{
    partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Button buttonImageConverter;
        private Button buttonWatermark;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonImageConverter = new Button();
            buttonWatermark = new Button();
            buttonPingCheck = new Button();
            btnOpenChat = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonImageConverter
            // 
            buttonImageConverter.BackColor = Color.FromArgb(50, 50, 50);
            buttonImageConverter.Dock = DockStyle.Fill;
            buttonImageConverter.FlatStyle = FlatStyle.Flat;
            buttonImageConverter.FlatAppearance.BorderSize = 0;
            buttonImageConverter.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            buttonImageConverter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonImageConverter.ForeColor = Color.White;
            buttonImageConverter.Location = new Point(3, 3);
            buttonImageConverter.Margin = new Padding(10);
            buttonImageConverter.Name = "buttonImageConverter";
            buttonImageConverter.Size = new Size(240, 50);
            buttonImageConverter.TabIndex = 0;
            buttonImageConverter.Text = "Image Converter";
            buttonImageConverter.UseVisualStyleBackColor = false;
            buttonImageConverter.Click += ImageConverter_Click;
            // 
            // buttonWatermark
            // 
            buttonWatermark.BackColor = Color.FromArgb(50, 50, 50);
            buttonWatermark.Dock = DockStyle.Fill;
            buttonWatermark.FlatStyle = FlatStyle.Flat;
            buttonWatermark.FlatAppearance.BorderSize = 0;
            buttonWatermark.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            buttonWatermark.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonWatermark.ForeColor = Color.White;
            buttonWatermark.Location = new Point(263, 3);
            buttonWatermark.Margin = new Padding(10);
            buttonWatermark.Name = "buttonWatermark";
            buttonWatermark.Size = new Size(240, 50);
            buttonWatermark.TabIndex = 1;
            buttonWatermark.Text = "Watermark Image";
            buttonWatermark.UseVisualStyleBackColor = false;
            buttonWatermark.Click += Watermark_Click;
            // 
            // buttonPingCheck
            // 
            buttonPingCheck.BackColor = Color.FromArgb(50, 50, 50);
            buttonPingCheck.Dock = DockStyle.Fill;
            buttonPingCheck.FlatStyle = FlatStyle.Flat;
            buttonPingCheck.FlatAppearance.BorderSize = 0;
            buttonPingCheck.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            buttonPingCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPingCheck.ForeColor = Color.White;
            buttonPingCheck.Location = new Point(523, 3);
            buttonPingCheck.Margin = new Padding(10);
            buttonPingCheck.Name = "buttonPingCheck";
            buttonPingCheck.Size = new Size(240, 50);
            buttonPingCheck.TabIndex = 2;
            buttonPingCheck.Text = "Check Ping";
            buttonPingCheck.UseVisualStyleBackColor = false;
            buttonPingCheck.Click += PingCheck_Click;
            // 
            // btnOpenChat
            // 
            btnOpenChat.BackColor = Color.FromArgb(50, 50, 50);
            btnOpenChat.Dock = DockStyle.Fill;
            btnOpenChat.FlatStyle = FlatStyle.Flat;
            btnOpenChat.FlatAppearance.BorderSize = 0;
            btnOpenChat.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnOpenChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOpenChat.ForeColor = Color.White;
            btnOpenChat.Location = new Point(783, 3);
            btnOpenChat.Margin = new Padding(10);
            btnOpenChat.Name = "btnOpenChat";
            btnOpenChat.Size = new Size(240, 50);
            btnOpenChat.TabIndex = 3;
            btnOpenChat.Text = "Chat";
            btnOpenChat.UseVisualStyleBackColor = false;
            btnOpenChat.Click += OpenChat_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(buttonImageConverter, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonWatermark, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonPingCheck, 2, 0);
            tableLayoutPanel1.Controls.Add(btnOpenChat, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1025, 70);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Matrise";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
