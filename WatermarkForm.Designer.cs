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

     

        private void InitializeComponent()
        {
            // Base form design with dark theme
            BackColor = Color.FromArgb(30, 30, 30);  // Darker background
            ForeColor = Color.White;  // White font for labels

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Watermark Image";
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            // PictureBox
            pictureBox = new PictureBox();
            pictureBox.BackColor = Color.FromArgb(45, 45, 45);
            pictureBox.Location = new Point(20, 70);
            pictureBox.Size = new Size(1000, 600);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            // Upload Button
            btnUpload = CreateButton("Upload Image", new Point(1050, 70), Color.FromArgb(33, 150, 243));

            // Apply Watermark Button
            btnApplyWatermark = CreateButton("Apply Watermark", new Point(1050, 140), Color.FromArgb(76, 175, 80));

            // Save Button
            btnSave = CreateButton("Save Image", new Point(1050, 210), Color.FromArgb(0, 188, 212));

            // Cancel Button
            btnCancel = CreateButton("Cancel", new Point(1050, 280), Color.FromArgb(188, 188, 188));

            // Invisible Watermark Button
            btnAddInvisibleWatermark = CreateButton("Add Invisible Watermark", new Point(1050, 350), Color.FromArgb(255, 87, 34));

            // Watermark Textbox
            txtWatermark = CreateTextBox(new Point(1050, 430), "Enter watermark text here");

            // Author Label
            lblAuthor = new Label();
            lblAuthor.Text = "Author:";
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAuthor.ForeColor = Color.White;
            lblAuthor.Location = new Point(1050, 480);
            lblAuthor.AutoSize = true;

            // Author Textbox
            txtAuthor = CreateTextBox(new Point(1050, 510), "Enter author name");

            // Copyright Label
            lblCopyright = new Label();
            lblCopyright.Text = "Copyright:";
            lblCopyright.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCopyright.ForeColor = Color.White;
            lblCopyright.Location = new Point(1050, 570);
            lblCopyright.AutoSize = true;

            // Copyright Textbox
            txtCopyright = CreateTextBox(new Point(1050, 600), "Enter copyright information");

            // Form Setup
            this.ClientSize = new Size(1280, 720);
            this.Controls.Add(lblTitle);
            this.Controls.Add(pictureBox);
            this.Controls.Add(btnUpload);
            this.Controls.Add(btnApplyWatermark);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnAddInvisibleWatermark);
            this.Controls.Add(txtWatermark);
            this.Controls.Add(lblAuthor);
            this.Controls.Add(txtAuthor);
            this.Controls.Add(lblCopyright);
            this.Controls.Add(txtCopyright);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WatermarkForm";
            this.Text = "Watermark Image";
        }

        private Button CreateButton(string text, Point location, Color backColor)
        {
            Button button = new Button();
            button.Text = text;
            button.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.BackColor = backColor;
            button.Size = new Size(200, 50);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Location = location;
            button.Cursor = Cursors.Hand;
            return button;
        }

        private TextBox CreateTextBox(Point location, string placeholder)
        {
            TextBox textBox = new TextBox();
            textBox.Font = new Font("Segoe UI", 12F);
            textBox.ForeColor = Color.WhiteSmoke;
            textBox.BackColor = Color.FromArgb(50, 50, 50);
            textBox.Size = new Size(220, 30);
            textBox.Location = location;
            textBox.PlaceholderText = placeholder;
            return textBox;
        }
    }
}
