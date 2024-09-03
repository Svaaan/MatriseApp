using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sp00ksy
{
    partial class NetCheckForm : Form
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
            speedTestButton = new Button();
            downloadSpeedLabel = new Label();
            uploadSpeedLabel = new Label();
            downloadProgressBar = new ProgressBar();
            uploadProgressBar = new ProgressBar();
            numberOfTestsUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numberOfTestsUpDown).BeginInit();
            SuspendLayout();
            // 
            // speedTestButton
            // 
            speedTestButton.BackColor = Color.Black;
            speedTestButton.Font = new Font("Viner Hand ITC", 15.75F, FontStyle.Bold);
            speedTestButton.ForeColor = Color.White;
            speedTestButton.Location = new Point(401, 283);
            speedTestButton.Name = "speedTestButton";
            speedTestButton.Size = new Size(244, 53);
            speedTestButton.TabIndex = 0;
            speedTestButton.Text = "Start Speed Test";
            speedTestButton.UseVisualStyleBackColor = false;
            speedTestButton.Click += SpeedTestButton_Click;
            // 
            // downloadSpeedLabel
            // 
            downloadSpeedLabel.AutoSize = true;
            downloadSpeedLabel.BackColor = Color.Black;
            downloadSpeedLabel.Font = new Font("Viner Hand ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            downloadSpeedLabel.ForeColor = Color.White;
            downloadSpeedLabel.Location = new Point(401, 55);
            downloadSpeedLabel.Name = "downloadSpeedLabel";
            downloadSpeedLabel.Size = new Size(290, 34);
            downloadSpeedLabel.TabIndex = 1;
            downloadSpeedLabel.Text = "Download Speed: 0.00 Mbps";
            // 
            // uploadSpeedLabel
            // 
            uploadSpeedLabel.AutoSize = true;
            uploadSpeedLabel.BackColor = Color.Black;
            uploadSpeedLabel.Font = new Font("Viner Hand ITC", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uploadSpeedLabel.ForeColor = Color.White;
            uploadSpeedLabel.Location = new Point(401, 177);
            uploadSpeedLabel.Name = "uploadSpeedLabel";
            uploadSpeedLabel.Size = new Size(259, 34);
            uploadSpeedLabel.TabIndex = 2;
            uploadSpeedLabel.Text = "Upload Speed: 0.00 Mbps";
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(344, 132);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(400, 23);
            downloadProgressBar.TabIndex = 3;
            // 
            // uploadProgressBar
            // 
            uploadProgressBar.BackColor = Color.Black;
            uploadProgressBar.ForeColor = Color.White;
            uploadProgressBar.Location = new Point(344, 229);
            uploadProgressBar.Name = "uploadProgressBar";
            uploadProgressBar.Size = new Size(400, 23);
            uploadProgressBar.TabIndex = 4;
            // 
            // numberOfTestsUpDown
            // 
            numberOfTestsUpDown.Location = new Point(461, 370);
            numberOfTestsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numberOfTestsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberOfTestsUpDown.Name = "numberOfTestsUpDown";
            numberOfTestsUpDown.Size = new Size(120, 23);
            numberOfTestsUpDown.TabIndex = 5;
            numberOfTestsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NetCheckForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1025, 487);
            Controls.Add(numberOfTestsUpDown);
            Controls.Add(speedTestButton);
            Controls.Add(downloadSpeedLabel);
            Controls.Add(uploadSpeedLabel);
            Controls.Add(downloadProgressBar);
            Controls.Add(uploadProgressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "NetCheckForm";
            Text = "Network Speed Test";
            ((System.ComponentModel.ISupportInitialize)numberOfTestsUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button speedTestButton;
        private Label downloadSpeedLabel;
        private Label uploadSpeedLabel;
        private ProgressBar downloadProgressBar;
        private ProgressBar uploadProgressBar;
        private NumericUpDown numberOfTestsUpDown; // Declare NumericUpDown control


    }
}
