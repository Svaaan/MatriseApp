namespace Sp00ksy
{
    partial class IpChatConnection
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
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnShowPorts = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(87, 371);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(174, 23);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(87, 404);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(174, 23);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8080";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(269, 368);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(117, 27);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(269, 401);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 27);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnShowPorts
            // 
            this.btnShowPorts.Location = new System.Drawing.Point(405, 369);
            this.btnShowPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShowPorts.Name = "btnShowPorts";
            this.btnShowPorts.Size = new System.Drawing.Size(117, 27);
            this.btnShowPorts.TabIndex = 7;
            this.btnShowPorts.Text = "Show Open Ports";
            this.btnShowPorts.UseVisualStyleBackColor = true;
            this.btnShowPorts.Click += new System.EventHandler(this.btnShowPorts_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(14, 373);
            this.labelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(62, 15);
            this.labelIP.TabIndex = 10;
            this.labelIP.Text = "IP Address";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(14, 407);
            this.labelPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 15);
            this.labelPort.TabIndex = 11;
            this.labelPort.Text = "Port";
            // 
            // IpChatConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(728, 510);
            this.Controls.Add(this.btnShowPorts);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "IpChatConnection";
            this.Text = "Chat Connection";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnShowPorts;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
    }
}
