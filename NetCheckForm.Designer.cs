namespace Sp00ksy
{
    partial class NetCheckForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button speedTestButton;
        private Label downloadSpeedLabel;
        private Label uploadSpeedLabel;
        private ProgressBar downloadProgressBar;
        private ProgressBar uploadProgressBar;
        private NumericUpDown numberOfTestsUpDown;

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
            this.speedTestButton = new System.Windows.Forms.Button();
            this.downloadSpeedLabel = new System.Windows.Forms.Label();
            this.uploadSpeedLabel = new System.Windows.Forms.Label();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.numberOfTestsUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTestsUpDown)).BeginInit();
            this.SuspendLayout();

            // 
            // speedTestButton
            // 
            this.speedTestButton.BackColor = Color.FromArgb(50, 150, 250);
            this.speedTestButton.FlatStyle = FlatStyle.Flat;
            this.speedTestButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.speedTestButton.ForeColor = Color.White;
            this.speedTestButton.Location = new Point(401, 283);
            this.speedTestButton.Name = "speedTestButton";
            this.speedTestButton.Size = new Size(244, 53);
            this.speedTestButton.TabIndex = 0;
            this.speedTestButton.Text = "Start Speed Test";
            this.speedTestButton.UseVisualStyleBackColor = false;
            this.speedTestButton.Click += new System.EventHandler(this.SpeedTestButton_Click);

            // 
            // downloadSpeedLabel
            // 
            this.downloadSpeedLabel.AutoSize = true;
            this.downloadSpeedLabel.BackColor = Color.FromArgb(20, 20, 20);
            this.downloadSpeedLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.downloadSpeedLabel.ForeColor = Color.White;
            this.downloadSpeedLabel.Location = new Point(401, 55);
            this.downloadSpeedLabel.Name = "downloadSpeedLabel";
            this.downloadSpeedLabel.Size = new Size(290, 25);
            this.downloadSpeedLabel.TabIndex = 1;
            this.downloadSpeedLabel.Text = "Download Speed: 0.00 Mbps";

            // 
            // uploadSpeedLabel
            // 
            this.uploadSpeedLabel.AutoSize = true;
            this.uploadSpeedLabel.BackColor = Color.FromArgb(20, 20, 20);
            this.uploadSpeedLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.uploadSpeedLabel.ForeColor = Color.White;
            this.uploadSpeedLabel.Location = new Point(401, 177);
            this.uploadSpeedLabel.Name = "uploadSpeedLabel";
            this.uploadSpeedLabel.Size = new Size(259, 25);
            this.uploadSpeedLabel.TabIndex = 2;
            this.uploadSpeedLabel.Text = "Upload Speed: 0.00 Mbps";

            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.BackColor = Color.FromArgb(30, 30, 30);
            this.downloadProgressBar.ForeColor = Color.FromArgb(50, 150, 250);
            this.downloadProgressBar.Location = new Point(344, 132);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new Size(400, 23);
            this.downloadProgressBar.Style = ProgressBarStyle.Continuous;
            this.downloadProgressBar.TabIndex = 3;

            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.BackColor = Color.FromArgb(30, 30, 30);
            this.uploadProgressBar.ForeColor = Color.FromArgb(250, 100, 100);
            this.uploadProgressBar.Location = new Point(344, 229);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new Size(400, 23);
            this.uploadProgressBar.Style = ProgressBarStyle.Continuous;
            this.uploadProgressBar.TabIndex = 4;

            // 
            // numberOfTestsUpDown
            // 
            this.numberOfTestsUpDown.BackColor = Color.FromArgb(40, 40, 40);
            this.numberOfTestsUpDown.ForeColor = Color.White;
            this.numberOfTestsUpDown.BorderStyle = BorderStyle.None;
            this.numberOfTestsUpDown.Location = new Point(461, 370);
            this.numberOfTestsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numberOfTestsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numberOfTestsUpDown.Name = "numberOfTestsUpDown";
            this.numberOfTestsUpDown.Size = new Size(120, 20);
            this.numberOfTestsUpDown.TabIndex = 5;
            this.numberOfTestsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // NetCheckForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(20, 20, 20);
            this.ClientSize = new Size(1025, 487);
            this.Controls.Add(this.numberOfTestsUpDown);
            this.Controls.Add(this.speedTestButton);
            this.Controls.Add(this.downloadSpeedLabel);
            this.Controls.Add(this.uploadSpeedLabel);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.uploadProgressBar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NetCheckForm";
            this.Text = "Network Speed Test";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfTestsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
