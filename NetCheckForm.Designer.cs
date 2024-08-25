namespace Sp00ksy
{
    partial class NetCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetCheckForm));
            speedTestButton = new Button();
            downloadSpeedLabel = new Label();
            uploadSpeedLabel = new Label();
            downloadProgressBar = new ProgressBar();
            uploadProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // speedTestButton
            // 
            speedTestButton.Location = new Point(277, 300);
            speedTestButton.Name = "speedTestButton";
            speedTestButton.Size = new Size(180, 53);
            speedTestButton.TabIndex = 0;
            speedTestButton.Text = "Start Speed Test";
            speedTestButton.UseVisualStyleBackColor = true;
            speedTestButton.Click += SpeedTestButton_Click;
            // 
            // downloadSpeedLabel
            // 
            downloadSpeedLabel.AutoSize = true;
            downloadSpeedLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            downloadSpeedLabel.ForeColor = Color.White;
            downloadSpeedLabel.Location = new Point(50, 100);
            downloadSpeedLabel.Name = "downloadSpeedLabel";
            downloadSpeedLabel.Size = new Size(227, 19);
            downloadSpeedLabel.TabIndex = 1;
            downloadSpeedLabel.Text = "Download Speed: 0.00 Mbps";
            // 
            // uploadSpeedLabel
            // 
            uploadSpeedLabel.AutoSize = true;
            uploadSpeedLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            uploadSpeedLabel.ForeColor = Color.White;
            uploadSpeedLabel.Location = new Point(50, 160);
            uploadSpeedLabel.Name = "uploadSpeedLabel";
            uploadSpeedLabel.Size = new Size(204, 19);
            uploadSpeedLabel.TabIndex = 2;
            uploadSpeedLabel.Text = "Upload Speed: 0.00 Mbps";
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(50, 130);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(400, 23);
            downloadProgressBar.TabIndex = 3;
            // 
            // uploadProgressBar
            // 
            uploadProgressBar.Location = new Point(50, 190);
            uploadProgressBar.Name = "uploadProgressBar";
            uploadProgressBar.Size = new Size(400, 23);
            uploadProgressBar.TabIndex = 4;
            // 
            // NetCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(speedTestButton);
            Controls.Add(downloadSpeedLabel);
            Controls.Add(uploadSpeedLabel);
            Controls.Add(downloadProgressBar);
            Controls.Add(uploadProgressBar);
            Name = "NetCheckForm";
            Text = "Network Speed Test";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button speedTestButton;
        private Label downloadSpeedLabel;
        private Label uploadSpeedLabel;
        private ProgressBar downloadProgressBar;
        private ProgressBar uploadProgressBar;
    }
}
