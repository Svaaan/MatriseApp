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

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageConverterForm));
            buttonUpload = new Button();
            buttonConvert = new Button();
            pictureBox = new PictureBox();
            tableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();

            this.MaximizeBox = false; // Disable the maximize button
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 
            // buttonUpload
            // 
            buttonUpload.BackColor = Color.Transparent;
            buttonUpload.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUpload.Font = new Font("Viner Hand ITC", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonUpload.Size = new Size(165, 60); // Reduced size by 25%
            buttonUpload.Margin = new Padding(10);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Text = "Upload Image";
            buttonUpload.UseVisualStyleBackColor = false;
            buttonUpload.Anchor = AnchorStyles.None; // Center within its cell

            // 
            // buttonConvert
            // 
            buttonConvert.BackColor = Color.Transparent;
            buttonConvert.BackgroundImageLayout = ImageLayout.Stretch;
            buttonConvert.Font = new Font("Viner Hand ITC", 11F, FontStyle.Bold);
            buttonConvert.Size = new Size(165, 60); // Reduced size by 25%
            buttonConvert.Margin = new Padding(10);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Text = "Convert Image";
            buttonConvert.UseVisualStyleBackColor = false;
            buttonConvert.Anchor = AnchorStyles.None; // Center within its cell

            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Size = new Size(720, 432); // Increased size by 20%
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            pictureBox.Anchor = AnchorStyles.None; // Center within its cell

            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackgroundImage = (Image)resources.GetObject("tableLayoutPanel.BackgroundImage");
            tableLayoutPanel.BackgroundImageLayout = ImageLayout.Stretch;
            tableLayoutPanel.ColumnCount = 1; // Single column layout
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // 100% width for single column
            tableLayoutPanel.Controls.Add(buttonUpload, 0, 0); // Place buttonUpload in first row
            tableLayoutPanel.Controls.Add(buttonConvert, 0, 1); // Place buttonConvert in second row
            tableLayoutPanel.Controls.Add(pictureBox, 0, 2); // Place pictureBox in third row
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // Fixed height for first row (buttonUpload)
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // Fixed height for second row (buttonConvert)
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Remaining space for pictureBox
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F)); // Optional padding row
            tableLayoutPanel.Size = new Size(1136, 667);
            tableLayoutPanel.TabIndex = 0;

            // 
            // ImageConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1136, 667);
            Controls.Add(tableLayoutPanel);
            Name = "ImageConverterForm";
            Text = "Image Converter";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
