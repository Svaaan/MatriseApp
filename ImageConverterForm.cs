using System;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;

namespace Sp00ksy
{
    public partial class ImageConverterForm : Form
    {
        private MagickImage uploadedImage;

        public ImageConverterForm()
        {
            InitializeComponent();
            buttonUpload.Text = "Upload Image";
            buttonConvert.Text = "Convert Image";
            buttonUpload.Click += ButtonUpload_Click;
            buttonConvert.Click += ButtonConvert_Click;
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.avif;*.webp;*.png;*.jpeg;*.jpg";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        var settings = new MagickReadSettings
                        {
                            Width = 1024,
                            Height = 1024
                        };

                        uploadedImage = new MagickImage(filePath, settings);

                        // Convert to Bitmap for preview
                        Bitmap bitmap = uploadedImage.ToBitmap();
                        pictureBox.Image = bitmap; // Display the image in the PictureBox
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("The image is too large to process. Please select a smaller image.", "Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            if (uploadedImage == null)
            {
                MessageBox.Show("Please upload an image first.", "No Image Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Allow saving in PNG, JPEG, and WebP formats
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|WebP Image|*.webp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    uploadedImage.Write(savePath); // Save the image in the selected format
                    MessageBox.Show("Image converted and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
