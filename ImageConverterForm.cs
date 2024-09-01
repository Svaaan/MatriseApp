using System;
using System.Drawing;
using System.IO;
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
                            // Load the image with the original size
                            Width = 1024,
                            Height = 1024
                        };

                        uploadedImage = new MagickImage(filePath, settings);

                        // Resize to a reasonable preview size
                        uploadedImage.Resize(new MagickGeometry(256, 256)
                        {
                            IgnoreAspectRatio = false
                        });

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
                // Allow saving in PNG, JPEG, WebP, and ICO formats
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|WebP Image|*.webp|ICO Image|*.ico";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    // Check if the selected format is ICO
                    if (Path.GetExtension(savePath).ToLower() == ".ico")
                    {
                        // Save as ICO format
                        using (var iconCollection = new MagickImageCollection())
                        {
                            // Add various sizes to the icon collection
                            AddImageToIconCollection(uploadedImage, iconCollection, 16);
                            AddImageToIconCollection(uploadedImage, iconCollection, 32);
                            AddImageToIconCollection(uploadedImage, iconCollection, 48);
                            AddImageToIconCollection(uploadedImage, iconCollection, 64);
                            AddImageToIconCollection(uploadedImage, iconCollection, 128);

                            // Write the collection to ICO file
                            iconCollection.Write(savePath);
                        }
                    }
                    else
                    {
                        // Save in selected format
                        uploadedImage.Write(savePath);
                    }

                    MessageBox.Show("Image converted and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddImageToIconCollection(MagickImage sourceImage, MagickImageCollection iconCollection, int size)
        {
            var iconImage = sourceImage.Clone();
            iconImage.Resize(size, size); // Resize to the desired icon size
            iconCollection.Add(iconImage);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ImageConverterForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ImageConverterForm_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click_1(object sender, EventArgs e)
        {

        }

        private void ImageConverterForm_Load_2(object sender, EventArgs e)
        {

        }

        private void buttonUpload_Click_1(object sender, EventArgs e)
        {

        }
    }
}
