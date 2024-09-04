namespace Matrise
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
            this.btnStartConnect = new System.Windows.Forms.Button();
            this.btnShowPorts = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
    

            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtIPAddress.ForeColor = System.Drawing.Color.White;
            this.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIPAddress.Location = new System.Drawing.Point(90, 100);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(174, 22);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.Location = new System.Drawing.Point(90, 135);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(174, 22);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8080";
            // 
            // btnStartConnect
            // 
            this.btnStartConnect.BackColor = System.Drawing.Color.FromArgb(50, 150, 250);
            this.btnStartConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartConnect.ForeColor = System.Drawing.Color.White;
            this.btnStartConnect.Location = new System.Drawing.Point(270, 100);
            this.btnStartConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartConnect.Name = "btnStartConnect";
            this.btnStartConnect.Size = new System.Drawing.Size(117, 27);
            this.btnStartConnect.TabIndex = 4;
            this.btnStartConnect.Text = "Start Server";
            this.btnStartConnect.UseVisualStyleBackColor = false;
            this.btnStartConnect.Click += new System.EventHandler(this.btnStartConnect_Click);
            // 
            // btnShowPorts
            // 
            this.btnShowPorts.BackColor = System.Drawing.Color.FromArgb(250, 100, 100);
            this.btnShowPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPorts.ForeColor = System.Drawing.Color.White;
            this.btnShowPorts.Location = new System.Drawing.Point(405, 100);
            this.btnShowPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShowPorts.Name = "btnShowPorts";
            this.btnShowPorts.Size = new System.Drawing.Size(117, 27);
            this.btnShowPorts.TabIndex = 7;
            this.btnShowPorts.Text = "Show Open Ports";
            this.btnShowPorts.UseVisualStyleBackColor = false;
            this.btnShowPorts.Click += new System.EventHandler(this.btnShowPorts_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.ForeColor = System.Drawing.Color.White;
            this.labelIP.Location = new System.Drawing.Point(17, 103);
            this.labelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(62, 15);
            this.labelIP.TabIndex = 10;
            this.labelIP.Text = "IP Address";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Location = new System.Drawing.Point(17, 138);
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
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.ClientSize = new System.Drawing.Size(540, 210);
            this.Controls.Add(this.btnShowPorts);
            this.Controls.Add(this.btnStartConnect);
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
        private System.Windows.Forms.Button btnStartConnect;
        private System.Windows.Forms.Button btnShowPorts;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
    }
}
