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
        private Button btnAddInvisibleWatermark;
        private PictureBox pictureBox;
        private TextBox txtWatermark;
        private TextBox txtAuthor;
        private TextBox txtCopyright;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblCopyright;

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
            btnAddInvisibleWatermark = new Button();
            pictureBox = new PictureBox();
            txtWatermark = new TextBox();
            txtAuthor = new TextBox();
            txtCopyright = new TextBox();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblCopyright = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpload.BackColor = Color.FromArgb(33, 150, 243);
            btnUpload.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(661, 84);
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
            btnApplyWatermark.Location = new Point(995, 84);
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
            btnSave.Location = new Point(995, 760);
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
            btnCancel.Location = new Point(661, 760);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAddInvisibleWatermark
            // 
            btnAddInvisibleWatermark.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddInvisibleWatermark.BackColor = Color.FromArgb(255, 87, 34);
            btnAddInvisibleWatermark.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddInvisibleWatermark.ForeColor = Color.White;
            btnAddInvisibleWatermark.Location = new Point(158, 290);
            btnAddInvisibleWatermark.Name = "btnAddInvisibleWatermark";
            btnAddInvisibleWatermark.Size = new Size(200, 50);
            btnAddInvisibleWatermark.TabIndex = 7;
            btnAddInvisibleWatermark.Text = "Add Invisible Watermark";
            btnAddInvisibleWatermark.UseVisualStyleBackColor = false;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(461, 167);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(941, 545);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // txtWatermark
            // 
            txtWatermark.Font = new Font("Segoe UI", 12F);
            txtWatermark.ForeColor = Color.DarkSlateGray;
            txtWatermark.Location = new Point(755, 31);
            txtWatermark.Name = "txtWatermark";
            txtWatermark.PlaceholderText = "Enter watermark text here";
            txtWatermark.Size = new Size(300, 29);
            txtWatermark.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 12F);
            txtAuthor.ForeColor = Color.DarkSlateGray;
            txtAuthor.Location = new Point(143, 149);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "Enter author name";
            txtAuthor.Size = new Size(228, 29);
            txtAuthor.TabIndex = 8;
            // 
            // txtCopyright
            // 
            txtCopyright.Font = new Font("Segoe UI", 12F);
            txtCopyright.ForeColor = Color.DarkSlateGray;
            txtCopyright.Location = new Point(143, 231);
            txtCopyright.Name = "txtCopyright";
            txtCopyright.PlaceholderText = "Enter copyright information";
            txtCopyright.Size = new Size(228, 29);
            txtCopyright.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkSlateGray;
            lblTitle.Location = new Point(755, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 32);
            lblTitle.TabIndex = 0;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAuthor.ForeColor = Color.DarkSlateGray;
            lblAuthor.Location = new Point(215, 113);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(68, 21);
            lblAuthor.TabIndex = 10;
            lblAuthor.Text = "Author:";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCopyright.ForeColor = Color.DarkSlateGray;
            lblCopyright.Location = new Point(193, 197);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(90, 21);
            lblCopyright.TabIndex = 11;
            lblCopyright.Text = "Copyright:";
            // 
            // WatermarkForm
            // 
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(1747, 887);
            Controls.Add(lblCopyright);
            Controls.Add(lblAuthor);
            Controls.Add(txtCopyright);
            Controls.Add(txtAuthor);
            Controls.Add(lblTitle);
            Controls.Add(txtWatermark);
            Controls.Add(pictureBox);
            Controls.Add(btnUpload);
            Controls.Add(btnApplyWatermark);
            Controls.Add(btnAddInvisibleWatermark);
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
