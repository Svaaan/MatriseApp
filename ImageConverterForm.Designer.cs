using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sp00ksy
{
    partial class ImageConverterForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonUpload;
        private Button buttonConvert;
        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanel;

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
            buttonUpload = new Button();
            buttonConvert = new Button();
            pictureBox = new PictureBox();
            tableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 
            // buttonUpload
            // 
            buttonUpload.BackColor = Color.FromArgb(33, 150, 243); // Blue color
            buttonUpload.ForeColor = Color.White;
            buttonUpload.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonUpload.Size = new Size(200, 70);
            buttonUpload.Margin = new Padding(10);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Text = "Upload Image";
            buttonUpload.UseVisualStyleBackColor = false;
            buttonUpload.Anchor = AnchorStyles.None;

            // 
            // buttonConvert
            // 
            buttonConvert.BackColor = Color.FromArgb(76, 175, 80); // Green color
            buttonConvert.ForeColor = Color.White;
            buttonConvert.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonConvert.Size = new Size(200, 70);
            buttonConvert.Margin = new Padding(10);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Text = "Convert Image";
            buttonConvert.UseVisualStyleBackColor = false;
            buttonConvert.Anchor = AnchorStyles.None;

            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.FromArgb(48, 48, 48); // Dark gray color
            pictureBox.Size = new Size(720, 432);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            pictureBox.Anchor = AnchorStyles.None;

            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.FromArgb(28, 28, 28); // Dark background color
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(buttonUpload, 0, 0);
            tableLayoutPanel.Controls.Add(buttonConvert, 0, 1);
            tableLayoutPanel.Controls.Add(pictureBox, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(15); // Increased padding
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Increased padding row
            tableLayoutPanel.Size = new Size(1200, 700); // Slightly larger size
            tableLayoutPanel.TabIndex = 0;

            // 
            // ImageConverterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F); // Adjusted for better scaling
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24); // Very dark background color
            ClientSize = new Size(1200, 700); // Increased client size
            Controls.Add(tableLayoutPanel);
            Name = "ImageConverterForm";
            Text = "Image Converter";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
