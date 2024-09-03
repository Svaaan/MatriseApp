namespace Sp00ksy
{
    partial class PingCheckForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxIpAddress;
        private Button buttonPing;
        private Button buttonFetchIp;
        private GroupBox groupBoxPingResults;
        private Label labelAddress;
        private Label labelRoundtripTime;
        private Label labelTTL;
        private Label labelBufferSize;
        private Label labelBufferContent;
        private Label labelPingSuccessful;
        private Panel mainPanel;

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
            textBoxIpAddress = new TextBox();
            buttonPing = new Button();
            buttonFetchIp = new Button();
            groupBoxPingResults = new GroupBox();
            labelPingSuccessful = new Label();
            labelBufferSize = new Label();
            labelTTL = new Label();
            labelRoundtripTime = new Label();
            labelAddress = new Label();
            mainPanel = new Panel();
            groupBoxPingResults.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.BackColor = Color.FromArgb(30, 30, 30);
            textBoxIpAddress.BorderStyle = BorderStyle.None;
            textBoxIpAddress.ForeColor = Color.White;
            textBoxIpAddress.Location = new Point(401, 111);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.PlaceholderText = "Enter IP Address";
            textBoxIpAddress.Size = new Size(300, 16);
            textBoxIpAddress.TabIndex = 0;
            // 
            // buttonPing
            // 
            buttonPing.BackColor = Color.FromArgb(50, 150, 250);
            buttonPing.FlatStyle = FlatStyle.Flat;
            buttonPing.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonPing.ForeColor = Color.White;
            buttonPing.Location = new Point(581, 39);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(120, 40);
            buttonPing.TabIndex = 2;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = false;
            buttonPing.Click += ButtonPing_Click;
            // 
            // buttonFetchIp
            // 
            buttonFetchIp.BackColor = Color.FromArgb(50, 150, 250);
            buttonFetchIp.FlatStyle = FlatStyle.Flat;
            buttonFetchIp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonFetchIp.ForeColor = Color.White;
            buttonFetchIp.Location = new Point(401, 39);
            buttonFetchIp.Name = "buttonFetchIp";
            buttonFetchIp.Size = new Size(120, 40);
            buttonFetchIp.TabIndex = 1;
            buttonFetchIp.Text = "Fetch IP";
            buttonFetchIp.UseVisualStyleBackColor = false;
            buttonFetchIp.Click += ButtonFetchIp_Click;
            // 
            // groupBoxPingResults
            // 
            groupBoxPingResults.Controls.Add(labelPingSuccessful);
            groupBoxPingResults.Controls.Add(labelBufferSize);
            groupBoxPingResults.Controls.Add(labelTTL);
            groupBoxPingResults.Controls.Add(labelRoundtripTime);
            groupBoxPingResults.Controls.Add(labelAddress);
            groupBoxPingResults.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBoxPingResults.ForeColor = Color.White;
            groupBoxPingResults.Location = new Point(242, 156);
            groupBoxPingResults.Name = "groupBoxPingResults";
            groupBoxPingResults.Size = new Size(583, 257);
            groupBoxPingResults.TabIndex = 3;
            groupBoxPingResults.TabStop = false;
            groupBoxPingResults.Text = "Ping Results";
            groupBoxPingResults.Visible = false;
            // 
            // labelPingSuccessful
            // 
            labelPingSuccessful.AutoSize = true;
            labelPingSuccessful.ForeColor = Color.White;
            labelPingSuccessful.Location = new Point(10, 208);
            labelPingSuccessful.Name = "labelPingSuccessful";
            labelPingSuccessful.Size = new Size(132, 21);
            labelPingSuccessful.TabIndex = 5;
            labelPingSuccessful.Text = "Ping Successful:";
            // 
            // labelBufferSize
            // 
            labelBufferSize.AutoSize = true;
            labelBufferSize.ForeColor = Color.White;
            labelBufferSize.Location = new Point(11, 168);
            labelBufferSize.Name = "labelBufferSize";
            labelBufferSize.Size = new Size(96, 21);
            labelBufferSize.TabIndex = 3;
            labelBufferSize.Text = "Buffer Size:";
            // 
            // labelTTL
            // 
            labelTTL.AutoSize = true;
            labelTTL.ForeColor = Color.White;
            labelTTL.Location = new Point(11, 125);
            labelTTL.Name = "labelTTL";
            labelTTL.Size = new Size(40, 21);
            labelTTL.TabIndex = 2;
            labelTTL.Text = "TTL:";
            // 
            // labelRoundtripTime
            // 
            labelRoundtripTime.AutoSize = true;
            labelRoundtripTime.ForeColor = Color.White;
            labelRoundtripTime.Location = new Point(10, 86);
            labelRoundtripTime.Name = "labelRoundtripTime";
            labelRoundtripTime.Size = new Size(133, 21);
            labelRoundtripTime.TabIndex = 1;
            labelRoundtripTime.Text = "Roundtrip Time:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.ForeColor = Color.White;
            labelAddress.Location = new Point(11, 44);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(74, 21);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Address:";
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.FromArgb(20, 20, 20);
            mainPanel.Controls.Add(buttonFetchIp);
            mainPanel.Controls.Add(buttonPing);
            mainPanel.Controls.Add(textBoxIpAddress);
            mainPanel.Controls.Add(groupBoxPingResults);
            mainPanel.Location = new Point(2, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1024, 472);
            mainPanel.TabIndex = 0;
            // 
            // PingCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1025, 487);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PingCheckForm";
            Text = "Ping";
            groupBoxPingResults.ResumeLayout(false);
            groupBoxPingResults.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
