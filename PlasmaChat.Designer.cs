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
            txtChatLog = new RichTextBox();
            txtIPAddress = new TextBox();
            txtPort = new TextBox();
            txtMessage = new TextBox();
            btnStartServer = new Button();
            btnConnect = new Button();
            btnSendMessage = new Button();
            btnShowPorts = new Button();
            btnSaveLogs = new Button();
            btnClearLogs = new Button();
            labelIP = new Label();
            labelPort = new Label();
            SuspendLayout();
            // 
            // txtChatLog
            // 
            txtChatLog.BackColor = Color.Black;
            txtChatLog.ForeColor = Color.White;
            txtChatLog.Location = new Point(14, 14);
            txtChatLog.Margin = new Padding(4, 3, 4, 3);
            txtChatLog.Name = "txtChatLog";
            txtChatLog.ReadOnly = true;
            txtChatLog.Size = new Size(699, 346);
            txtChatLog.TabIndex = 0;
            txtChatLog.Text = "";
            // 
            // txtIPAddress
            // 
            txtIPAddress.Location = new Point(87, 371);
            txtIPAddress.Margin = new Padding(4, 3, 4, 3);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.Size = new Size(174, 23);
            txtIPAddress.TabIndex = 1;
            txtIPAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(87, 404);
            txtPort.Margin = new Padding(4, 3, 4, 3);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(174, 23);
            txtPort.TabIndex = 2;
            txtPort.Text = "8080";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(87, 439);
            txtMessage.Margin = new Padding(4, 3, 4, 3);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(450, 23);
            txtMessage.TabIndex = 3;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(269, 368);
            btnStartServer.Margin = new Padding(4, 3, 4, 3);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(117, 27);
            btnStartServer.TabIndex = 4;
            btnStartServer.Text = "Start Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(269, 401);
            btnConnect.Margin = new Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(117, 27);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(548, 438);
            btnSendMessage.Margin = new Padding(4, 3, 4, 3);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(117, 27);
            btnSendMessage.TabIndex = 6;
            btnSendMessage.Text = "Send";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // btnShowPorts
            // 
            btnShowPorts.Location = new Point(405, 369);
            btnShowPorts.Margin = new Padding(4, 3, 4, 3);
            btnShowPorts.Name = "btnShowPorts";
            btnShowPorts.Size = new Size(117, 27);
            btnShowPorts.TabIndex = 7;
            btnShowPorts.Text = "Show Open Ports";
            btnShowPorts.UseVisualStyleBackColor = true;
            btnShowPorts.Click += btnShowPorts_Click;
            // 
            // btnSaveLogs
            // 
            btnSaveLogs.Location = new Point(548, 369);
            btnSaveLogs.Margin = new Padding(4, 3, 4, 3);
            btnSaveLogs.Name = "btnSaveLogs";
            btnSaveLogs.Size = new Size(117, 27);
            btnSaveLogs.TabIndex = 8;
            btnSaveLogs.Text = "Save Logs";
            btnSaveLogs.UseVisualStyleBackColor = true;
            btnSaveLogs.Click += btnSaveLogs_Click;
            // 
            // btnClearLogs
            // 
            btnClearLogs.Location = new Point(548, 404);
            btnClearLogs.Margin = new Padding(4, 3, 4, 3);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(117, 27);
            btnClearLogs.TabIndex = 9;
            btnClearLogs.Text = "Clear Logs";
            btnClearLogs.UseVisualStyleBackColor = true;
            btnClearLogs.Click += btnClearLogs_Click;
            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Location = new Point(14, 373);
            labelIP.Margin = new Padding(4, 0, 4, 0);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(62, 15);
            labelIP.TabIndex = 10;
            labelIP.Text = "IP Address";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(14, 407);
            labelPort.Margin = new Padding(4, 0, 4, 0);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(29, 15);
            labelPort.TabIndex = 11;
            labelPort.Text = "Port";
            // 
            // PlasmaChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(728, 474);
            Controls.Add(labelPort);
            Controls.Add(labelIP);
            Controls.Add(btnClearLogs);
            Controls.Add(btnSaveLogs);
            Controls.Add(btnShowPorts);
            Controls.Add(btnSendMessage);
            Controls.Add(btnConnect);
            Controls.Add(btnStartServer);
            Controls.Add(txtMessage);
            Controls.Add(txtPort);
            Controls.Add(txtIPAddress);
            Controls.Add(txtChatLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "PlasmaChat";
            Text = "PlasmaChat";
            FormClosing += PlasmaChat_FormClosing;
            ResumeLayout(false);
            PerformLayout();
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