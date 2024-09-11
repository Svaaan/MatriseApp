namespace Matrise
{
    partial class WatermarkForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button speedTestButton;
        private Label downloadSpeedLabel;
        private Label uploadSpeedLabel;
        private Label statusLabel;
        private TextBox resultsTextBox;
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
            speedTestButton = new Button();
            downloadSpeedLabel = new Label();
            uploadSpeedLabel = new Label();
            statusLabel = new Label();
            resultsTextBox = new TextBox();
            numberOfTestsUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numberOfTestsUpDown).BeginInit();
            SuspendLayout();
          
            // downloadSpeedLabel
            // 
            downloadSpeedLabel.AutoSize = true;
            downloadSpeedLabel.BackColor = Color.FromArgb(20, 20, 20);
            downloadSpeedLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            downloadSpeedLabel.ForeColor = Color.White;
            downloadSpeedLabel.Location = new Point(178, 57);
            downloadSpeedLabel.Name = "downloadSpeedLabel";
            downloadSpeedLabel.Size = new Size(267, 25);
            downloadSpeedLabel.TabIndex = 1;
            downloadSpeedLabel.Text = "Download Speed: 0.00 Mbps";
            // 
            // uploadSpeedLabel
            // 
            uploadSpeedLabel.AutoSize = true;
            uploadSpeedLabel.BackColor = Color.FromArgb(20, 20, 20);
            uploadSpeedLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            uploadSpeedLabel.ForeColor = Color.White;
            uploadSpeedLabel.Location = new Point(583, 57);
            uploadSpeedLabel.Name = "uploadSpeedLabel";
            uploadSpeedLabel.Size = new Size(240, 25);
            uploadSpeedLabel.TabIndex = 2;
            uploadSpeedLabel.Text = "Upload Speed: 0.00 Mbps";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.FromArgb(20, 20, 20);
            statusLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            statusLabel.ForeColor = Color.White;
            statusLabel.Location = new Point(446, 248);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(183, 21);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "Status: Waiting to start";
            // 
            // resultsTextBox
            // 
            resultsTextBox.BackColor = Color.FromArgb(40, 40, 40);
            resultsTextBox.ForeColor = Color.White;
            resultsTextBox.Location = new Point(251, 284);
            resultsTextBox.Multiline = true;
            resultsTextBox.Name = "resultsTextBox";
            resultsTextBox.ReadOnly = true;
            resultsTextBox.Size = new Size(590, 182);
            resultsTextBox.TabIndex = 4;
            // 
            // numberOfTestsUpDown
            // 
            numberOfTestsUpDown.BackColor = Color.FromArgb(40, 40, 40);
            numberOfTestsUpDown.BorderStyle = BorderStyle.None;
            numberOfTestsUpDown.ForeColor = Color.White;
            numberOfTestsUpDown.Location = new Point(472, 200);
            numberOfTestsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numberOfTestsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberOfTestsUpDown.Name = "numberOfTestsUpDown";
            numberOfTestsUpDown.Size = new Size(120, 19);
            numberOfTestsUpDown.TabIndex = 5;
            numberOfTestsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NetCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1025, 487);
            Controls.Add(numberOfTestsUpDown);
            Controls.Add(resultsTextBox);
            Controls.Add(statusLabel);
            Controls.Add(speedTestButton);
            Controls.Add(downloadSpeedLabel);
            Controls.Add(uploadSpeedLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "NetCheckForm";
            Text = "Network Speed Test";
            ((System.ComponentModel.ISupportInitialize)numberOfTestsUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
