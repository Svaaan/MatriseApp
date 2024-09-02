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
        private Label labelResult;
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
            mainPanel = new Panel();
            buttonFetchIp = new Button();
            buttonPing = new Button();
            labelResult = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();

            this.MaximizeBox = false; // Disable the maximize button
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Location = new Point(401, 218);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.PlaceholderText = "Enter IP Address";
            textBoxIpAddress.Size = new Size(300, 23);
            textBoxIpAddress.TabIndex = 0;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Controls.Add(buttonFetchIp);
            mainPanel.Controls.Add(buttonPing);
            mainPanel.Controls.Add(textBoxIpAddress);
            mainPanel.Controls.Add(labelResult);
            mainPanel.Location = new Point(2, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1024, 472);
            mainPanel.TabIndex = 0;
            // 
            // buttonFetchIp
            // 
            buttonFetchIp.BackColor = Color.LightGray;
            buttonFetchIp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonFetchIp.Location = new Point(401, 116);
            buttonFetchIp.Name = "buttonFetchIp";
            buttonFetchIp.Size = new Size(120, 40);
            buttonFetchIp.TabIndex = 1;
            buttonFetchIp.Text = "Fetch IP";
            buttonFetchIp.UseVisualStyleBackColor = true;
            // 
            // buttonPing
            // 
            buttonPing.BackColor = Color.LightGray;
            buttonPing.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonPing.Location = new Point(581, 116);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(120, 40);
            buttonPing.TabIndex = 2;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            labelResult.BackColor = Color.Transparent;
            labelResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelResult.Location = new Point(401, 262);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(300, 30);
            labelResult.TabIndex = 3;
            labelResult.Text = "Ping result will be displayed here.";
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PingCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(mainPanel);
            Name = "PingCheckForm";
            Text = "Check Ping";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
