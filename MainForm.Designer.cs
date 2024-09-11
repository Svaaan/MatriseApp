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
            buttonImageConverter.BackColor = Color.FromArgb(40, 40, 40);
            buttonImageConverter.Dock = DockStyle.Fill;
            buttonImageConverter.FlatStyle = FlatStyle.Flat;
            buttonImageConverter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonImageConverter.ForeColor = Color.White;
            buttonImageConverter.Location = new Point(3, 3);
            buttonImageConverter.Name = "buttonImageConverter";
            buttonImageConverter.Size = new Size(250, 34);
            buttonImageConverter.TabIndex = 0;
            buttonImageConverter.Text = "Image Converter";
            buttonImageConverter.UseVisualStyleBackColor = false;
            buttonImageConverter.Click += ImageConverter_Click;
            // 
            // buttonNetCheck
            // 
            buttonWatermark.BackColor = Color.FromArgb(40, 40, 40);
            buttonWatermark.Dock = DockStyle.Fill;
            buttonWatermark.FlatStyle = FlatStyle.Flat;
            buttonWatermark.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonWatermark.ForeColor = Color.White;
            buttonWatermark.Location = new Point(259, 3);
            buttonWatermark.Name = "buttonNetCheck";
            buttonWatermark.Size = new Size(250, 34);
            buttonWatermark.TabIndex = 1;
            buttonWatermark.Text = "Watermark image";
            buttonWatermark.UseVisualStyleBackColor = false;
            buttonWatermark.Click += NetCheck_Click;
            // 
            // buttonPingCheck
            // 
            buttonPingCheck.BackColor = Color.FromArgb(40, 40, 40);
            buttonPingCheck.Dock = DockStyle.Fill;
            buttonPingCheck.FlatStyle = FlatStyle.Flat;
            buttonPingCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonPingCheck.ForeColor = Color.White;
            buttonPingCheck.Location = new Point(515, 3);
            buttonPingCheck.Name = "buttonPingCheck";
            buttonPingCheck.Size = new Size(250, 34);
            buttonPingCheck.TabIndex = 2;
            buttonPingCheck.Text = "Check Ping";
            buttonPingCheck.UseVisualStyleBackColor = false;
            buttonPingCheck.Click += PingCheck_Click;
            // 
            // btnOpenChat
            // 
            btnOpenChat.BackColor = Color.FromArgb(40, 40, 40);
            btnOpenChat.Dock = DockStyle.Fill;
            btnOpenChat.FlatStyle = FlatStyle.Flat;
            btnOpenChat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOpenChat.ForeColor = Color.White;
            btnOpenChat.Location = new Point(771, 3);
            btnOpenChat.Name = "btnOpenChat";
            btnOpenChat.Size = new Size(251, 34);
            btnOpenChat.TabIndex = 3;
            btnOpenChat.Text = "Chat";
            btnOpenChat.UseVisualStyleBackColor = false;
            btnOpenChat.Click += btnOpenChat_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Black;
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
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1025, 40);
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
