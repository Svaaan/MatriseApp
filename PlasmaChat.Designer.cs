namespace Sp00ksy
{
    partial class PlasmaChat
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.txtChatLog = new System.Windows.Forms.RichTextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnShowPorts = new System.Windows.Forms.Button();
            this.btnSaveLogs = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.MaximizeBox = false; // Disable the maximize button
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // txtChatLog
            this.txtChatLog.BackColor = System.Drawing.Color.Black;
            this.txtChatLog.ForeColor = System.Drawing.Color.White;
            this.txtChatLog.Location = new System.Drawing.Point(12, 12);
            this.txtChatLog.Name = "txtChatLog";
            this.txtChatLog.ReadOnly = true;
            this.txtChatLog.Size = new System.Drawing.Size(600, 300);
            this.txtChatLog.TabIndex = 0;
            this.txtChatLog.Text = "";

            // txtIPAddress
            this.txtIPAddress.Location = new System.Drawing.Point(80, 320);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(150, 20);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "127.0.0.1"; // Default IP Address

            // txtPort
            this.txtPort.Location = new System.Drawing.Point(80, 350);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(150, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8080"; // Default Port

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(12, 380);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(400, 20);
            this.txtMessage.TabIndex = 3;

            // btnStartServer
            this.btnStartServer.Location = new System.Drawing.Point(250, 320);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 23);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);

            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(250, 350);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // btnSendMessage
            this.btnSendMessage.Location = new System.Drawing.Point(420, 380);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(100, 23);
            this.btnSendMessage.TabIndex = 6;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);

            // btnShowPorts
            this.btnShowPorts.Location = new System.Drawing.Point(360, 320); // Positioned to the right of btnStartServer
            this.btnShowPorts.Name = "btnShowPorts";
            this.btnShowPorts.Size = new System.Drawing.Size(100, 23);
            this.btnShowPorts.TabIndex = 7;
            this.btnShowPorts.Text = "Show Open Ports";
            this.btnShowPorts.UseVisualStyleBackColor = true;
            this.btnShowPorts.Click += new System.EventHandler(this.btnShowPorts_Click);

            // btnSaveLogs
            this.btnSaveLogs.Location = new System.Drawing.Point(470, 320); // Positioned to the right of btnShowPorts
            this.btnSaveLogs.Name = "btnSaveLogs";
            this.btnSaveLogs.Size = new System.Drawing.Size(100, 23);
            this.btnSaveLogs.TabIndex = 8;
            this.btnSaveLogs.Text = "Save Logs";
            this.btnSaveLogs.UseVisualStyleBackColor = true;
            this.btnSaveLogs.Click += new System.EventHandler(this.btnSaveLogs_Click);

            // btnClearLogs
            this.btnClearLogs.Location = new System.Drawing.Point(470, 350); // Positioned below btnSaveLogs
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(100, 23);
            this.btnClearLogs.TabIndex = 9;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);

            // labelIP
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 323);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(58, 13);
            this.labelIP.TabIndex = 10;
            this.labelIP.Text = "IP Address";

            // labelPort
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(12, 353);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 11;
            this.labelPort.Text = "Port";

            // PlasmaChat
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 411);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.btnSaveLogs);
            this.Controls.Add(this.btnShowPorts);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.txtChatLog);
            this.Name = "PlasmaChat";
            this.Text = "PlasmaChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlasmaChat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox txtChatLog;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnShowPorts;
        private System.Windows.Forms.Button btnSaveLogs;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
    }
}