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
            this.textBoxIpAddress = new System.Windows.Forms.TextBox();
            this.buttonPing = new System.Windows.Forms.Button();
            this.buttonFetchIp = new System.Windows.Forms.Button();
            this.groupBoxPingResults = new System.Windows.Forms.GroupBox();
            this.labelPingSuccessful = new System.Windows.Forms.Label();
            this.labelBufferSize = new System.Windows.Forms.Label();
            this.labelTTL = new System.Windows.Forms.Label();
            this.labelRoundtripTime = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBoxPingResults.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.BackColor = Color.FromArgb(30, 30, 30);
            this.textBoxIpAddress.ForeColor = Color.White;
            this.textBoxIpAddress.BorderStyle = BorderStyle.None;
            this.textBoxIpAddress.Location = new System.Drawing.Point(401, 111);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.PlaceholderText = "Enter IP Address";
            this.textBoxIpAddress.Size = new System.Drawing.Size(300, 23);
            this.textBoxIpAddress.TabIndex = 0;
            // 
            // buttonPing
            // 
            this.buttonPing.BackColor = Color.FromArgb(50, 150, 250);
            this.buttonPing.FlatStyle = FlatStyle.Flat;
            this.buttonPing.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.buttonPing.ForeColor = Color.White;
            this.buttonPing.Location = new System.Drawing.Point(581, 39);
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.Size = new System.Drawing.Size(120, 40);
            this.buttonPing.TabIndex = 2;
            this.buttonPing.Text = "Ping";
            this.buttonPing.UseVisualStyleBackColor = false;
            this.buttonPing.Click += new System.EventHandler(this.ButtonPing_Click);
            // 
            // buttonFetchIp
            // 
            this.buttonFetchIp.BackColor = Color.FromArgb(50, 150, 250);
            this.buttonFetchIp.FlatStyle = FlatStyle.Flat;
            this.buttonFetchIp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.buttonFetchIp.ForeColor = Color.White;
            this.buttonFetchIp.Location = new System.Drawing.Point(401, 39);
            this.buttonFetchIp.Name = "buttonFetchIp";
            this.buttonFetchIp.Size = new System.Drawing.Size(120, 40);
            this.buttonFetchIp.TabIndex = 1;
            this.buttonFetchIp.Text = "Fetch IP";
            this.buttonFetchIp.UseVisualStyleBackColor = false;
            this.buttonFetchIp.Click += new System.EventHandler(this.ButtonFetchIp_Click);
            // 
            // groupBoxPingResults
            // 
            this.groupBoxPingResults.Controls.Add(this.labelPingSuccessful);
            this.groupBoxPingResults.Controls.Add(this.labelBufferSize);
            this.groupBoxPingResults.Controls.Add(this.labelTTL);
            this.groupBoxPingResults.Controls.Add(this.labelRoundtripTime);
            this.groupBoxPingResults.Controls.Add(this.labelAddress);
            this.groupBoxPingResults.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.groupBoxPingResults.ForeColor = Color.White;
            this.groupBoxPingResults.Location = new System.Drawing.Point(242, 156);
            this.groupBoxPingResults.Name = "groupBoxPingResults";
            this.groupBoxPingResults.Size = new System.Drawing.Size(583, 257);
            this.groupBoxPingResults.TabIndex = 3;
            this.groupBoxPingResults.TabStop = false;
            this.groupBoxPingResults.Text = "Ping Results";
            this.groupBoxPingResults.Visible = false;
            // 
            // labelPingSuccessful
            // 
            this.labelPingSuccessful.AutoSize = true;
            this.labelPingSuccessful.ForeColor = Color.White;
            this.labelPingSuccessful.Location = new System.Drawing.Point(10, 208);
            this.labelPingSuccessful.Name = "labelPingSuccessful";
            this.labelPingSuccessful.Size = new System.Drawing.Size(132, 21);
            this.labelPingSuccessful.TabIndex = 5;
            this.labelPingSuccessful.Text = "Ping Successful:";
            // 
            // labelBufferSize
            // 
            this.labelBufferSize.AutoSize = true;
            this.labelBufferSize.ForeColor = Color.White;
            this.labelBufferSize.Location = new System.Drawing.Point(11, 168);
            this.labelBufferSize.Name = "labelBufferSize";
            this.labelBufferSize.Size = new System.Drawing.Size(96, 21);
            this.labelBufferSize.TabIndex = 3;
            this.labelBufferSize.Text = "Buffer Size:";
            // 
            // labelTTL
            // 
            this.labelTTL.AutoSize = true;
            this.labelTTL.ForeColor = Color.White;
            this.labelTTL.Location = new System.Drawing.Point(11, 125);
            this.labelTTL.Name = "labelTTL";
            this.labelTTL.Size = new System.Drawing.Size(40, 21);
            this.labelTTL.TabIndex = 2;
            this.labelTTL.Text = "TTL:";
            // 
            // labelRoundtripTime
            // 
            this.labelRoundtripTime.AutoSize = true;
            this.labelRoundtripTime.ForeColor = Color.White;
            this.labelRoundtripTime.Location = new System.Drawing.Point(10, 86);
            this.labelRoundtripTime.Name = "labelRoundtripTime";
            this.labelRoundtripTime.Size = new System.Drawing.Size(133, 21);
            this.labelRoundtripTime.TabIndex = 1;
            this.labelRoundtripTime.Text = "Roundtrip Time:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.ForeColor = Color.White;
            this.labelAddress.Location = new System.Drawing.Point(11, 44);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(74, 21);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Address:";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = AnchorStyles.None;
            this.mainPanel.BackColor = Color.FromArgb(20, 20, 20);
            this.mainPanel.Controls.Add(this.buttonFetchIp);
            this.mainPanel.Controls.Add(this.buttonPing);
            this.mainPanel.Controls.Add(this.textBoxIpAddress);
            this.mainPanel.Controls.Add(this.groupBoxPingResults);
            this.mainPanel.Location = new System.Drawing.Point(2, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1024, 472);
            this.mainPanel.TabIndex = 0;
            // 
            // PingCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new System.Drawing.Size(1025, 487);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PingCheckForm";
            this.Text = "Check Ping";
            this.groupBoxPingResults.ResumeLayout(false);
            this.groupBoxPingResults.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
        }

    }
}
