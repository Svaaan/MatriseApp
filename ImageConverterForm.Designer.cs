namespace Sp00ksy
{
    partial class ImageConverterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.PictureBox pictureBox;

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
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // buttonUpload
            // 
            buttonUpload.Location = new Point(20, 20);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Size = new Size(120, 40);
            buttonUpload.TabIndex = 0;
            buttonUpload.Text = "Upload Image";
            buttonUpload.UseVisualStyleBackColor = true;
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(160, 20);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(120, 40);
            buttonConvert.TabIndex = 1;
            buttonConvert.Text = "Convert Image";
            buttonConvert.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.ControlDark;
            pictureBox.Location = new Point(20, 80);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(400, 300);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // ImageConverterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1025, 487);
            Controls.Add(pictureBox);
            Controls.Add(buttonConvert);
            Controls.Add(buttonUpload);
            Name = "ImageConverterForm";
            Text = "Image Converter";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
