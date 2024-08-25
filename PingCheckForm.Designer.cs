namespace Sp00ksy
{
    partial class PingCheckForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxIpAddress;
        private System.Windows.Forms.Button buttonPing;
        private System.Windows.Forms.Button buttonFetchIp;
        private System.Windows.Forms.Label labelResult;

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
            labelResult = new Label();
            SuspendLayout();
            // 
            // textBoxIpAddress
            // 
            textBoxIpAddress.Location = new Point(20, 20);
            textBoxIpAddress.Name = "textBoxIpAddress";
            textBoxIpAddress.PlaceholderText = "Enter IP Address";
            textBoxIpAddress.Size = new Size(300, 23);
            textBoxIpAddress.TabIndex = 0;
            // 
            // buttonPing
            // 
            buttonPing.Location = new Point(340, 20);
            buttonPing.Name = "buttonPing";
            buttonPing.Size = new Size(100, 23);
            buttonPing.TabIndex = 1;
            buttonPing.Text = "Ping";
            buttonPing.UseVisualStyleBackColor = true;
            // 
            // buttonFetchIp
            // 
            buttonFetchIp.Location = new Point(340, 50);
            buttonFetchIp.Name = "buttonFetchIp";
            buttonFetchIp.Size = new Size(100, 23);
            buttonFetchIp.TabIndex = 2;
            buttonFetchIp.Text = "Fetch IP";
            buttonFetchIp.UseVisualStyleBackColor = true;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(20, 90);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(182, 15);
            labelResult.TabIndex = 3;
            labelResult.Text = "Ping result will be displayed here.";
            // 
            // PingCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(labelResult);
            Controls.Add(buttonFetchIp);
            Controls.Add(buttonPing);
            Controls.Add(textBoxIpAddress);
            Name = "PingCheckForm";
            Text = "Check Ping";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
