using System;
using System.Drawing;
using System.Windows.Forms;

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

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PingCheckForm));
            textBoxIpAddress = new TextBox();
            buttonPing = new Button();
            buttonFetchIp = new Button();
            groupBoxPingResults = new GroupBox();
            labelPingSuccessful = new Label();
            labelBufferContent = new Label();
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
            textBoxIpAddress.Location = new Point(401, 165);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.PlaceholderText = "Enter IP Address";
            textBoxIpAddress.Size = new Size(300, 23);
            textBoxIpAddress.TabIndex = 0;
            // 
            // buttonPing
            // 
            buttonPing.BackColor = Color.LightGray;
            buttonPing.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonPing.Location = new Point(581, 87);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(120, 40);
            buttonPing.TabIndex = 2;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = true;
            // 
            // buttonFetchIp
            // 
            buttonFetchIp.BackColor = Color.LightGray;
            buttonFetchIp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonFetchIp.Location = new Point(401, 87);
            buttonFetchIp.Name = "buttonFetchIp";
            buttonFetchIp.Size = new Size(120, 40);
            buttonFetchIp.TabIndex = 1;
            buttonFetchIp.Text = "Fetch IP";
            buttonFetchIp.UseVisualStyleBackColor = true;
            // 
            // groupBoxPingResults
            // 
            groupBoxPingResults.Controls.Add(labelPingSuccessful);
            groupBoxPingResults.Controls.Add(labelBufferContent);
            groupBoxPingResults.Controls.Add(labelBufferSize);
            groupBoxPingResults.Controls.Add(labelTTL);
            groupBoxPingResults.Controls.Add(labelRoundtripTime);
            groupBoxPingResults.Controls.Add(labelAddress);
            groupBoxPingResults.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPingResults.ForeColor = Color.White;
            groupBoxPingResults.Location = new Point(166, 215);
            groupBoxPingResults.Name = "groupBoxPingResults";
            groupBoxPingResults.Size = new Size(735, 254);
            groupBoxPingResults.TabIndex = 3;
            groupBoxPingResults.TabStop = false;
            groupBoxPingResults.Text = "Ping Results";
            groupBoxPingResults.Visible = false;
            groupBoxPingResults.Enter += groupBoxPingResults_Enter;
            // 
            // labelPingSuccessful
            // 
            labelPingSuccessful.AutoSize = true;
            labelPingSuccessful.Location = new Point(10, 208);
            labelPingSuccessful.Name = "labelPingSuccessful";
            labelPingSuccessful.Size = new Size(132, 21);
            labelPingSuccessful.TabIndex = 5;
            labelPingSuccessful.Text = "Ping Successful:";
            // 
            // labelBufferContent
            // 
            labelBufferContent.AutoSize = true;
            labelBufferContent.Location = new Point(10, 164);
            labelBufferContent.Name = "labelBufferContent";
            labelBufferContent.Size = new Size(126, 21);
            labelBufferContent.TabIndex = 4;
            labelBufferContent.Text = "Buffer Content:";
            // 
            // labelBufferSize
            // 
            labelBufferSize.AutoSize = true;
            labelBufferSize.Location = new Point(11, 131);
            labelBufferSize.Name = "labelBufferSize";
            labelBufferSize.Size = new Size(96, 21);
            labelBufferSize.TabIndex = 3;
            labelBufferSize.Text = "Buffer Size:";
            // 
            // labelTTL
            // 
            labelTTL.AutoSize = true;
            labelTTL.Location = new Point(11, 99);
            labelTTL.Name = "labelTTL";
            labelTTL.Size = new Size(40, 21);
            labelTTL.TabIndex = 2;
            labelTTL.Text = "TTL:";
            // 
            // labelRoundtripTime
            // 
            labelRoundtripTime.AutoSize = true;
            labelRoundtripTime.Location = new Point(11, 62);
            labelRoundtripTime.Name = "labelRoundtripTime";
            labelRoundtripTime.Size = new Size(133, 21);
            labelRoundtripTime.TabIndex = 1;
            labelRoundtripTime.Text = "Roundtrip Time:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(10, 25);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(74, 21);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Address:";
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.Transparent;
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
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PingCheckForm";
            Text = "Check Ping";
            groupBoxPingResults.ResumeLayout(false);
            groupBoxPingResults.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
