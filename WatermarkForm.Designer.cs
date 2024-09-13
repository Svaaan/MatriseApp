using System;
using System.Drawing;
using System.Windows.Forms;

namespace Matrise
{
    partial class WatermarkForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnUpload;
        private Button btnApplyWatermark;
        private Button btnSave;
        private Button btnCancel;
        private PictureBox pictureBox;
        private TextBox txtWatermark;
        private Label lblTitle;

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
            btnUpload = new Button();
            btnApplyWatermark = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            pictureBox = new PictureBox();
            txtWatermark = new TextBox();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpload.BackColor = Color.FromArgb(33, 150, 243);
            btnUpload.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(356, 117);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(200, 50);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "Upload Image";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // btnApplyWatermark
            // 
            btnApplyWatermark.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnApplyWatermark.BackColor = Color.FromArgb(76, 175, 80);
            btnApplyWatermark.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApplyWatermark.ForeColor = Color.White;
            btnApplyWatermark.Location = new Point(670, 117);
            btnApplyWatermark.Name = "btnApplyWatermark";
            btnApplyWatermark.Size = new Size(200, 50);
            btnApplyWatermark.TabIndex = 4;
            btnApplyWatermark.Text = "Apply Watermark";
            btnApplyWatermark.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(356, 585);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 50);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save Image";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.FromArgb(188, 188, 188);
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(670, 585);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.FromArgb(48, 48, 48);
            pictureBox.Location = new Point(286, 184);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(669, 380);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // txtWatermark
            // 
            txtWatermark.Font = new Font("Segoe UI", 12F);
            txtWatermark.ForeColor = Color.DarkSlateGray;
            txtWatermark.Location = new Point(477, 65);
            txtWatermark.Name = "txtWatermark";
            txtWatermark.PlaceholderText = "Enter watermark text here";
            txtWatermark.Size = new Size(300, 29);
            txtWatermark.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateGray;
            lblTitle.Location = new Point(533, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(194, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Watermark";
            // 
            // WatermarkForm
            // 
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1200, 700);
            Controls.Add(lblTitle);
            Controls.Add(txtWatermark);
            Controls.Add(pictureBox);
            Controls.Add(btnUpload);
            Controls.Add(btnApplyWatermark);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "WatermarkForm";
            Text = "Watermark Image";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
