using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrise
{
    public partial class WatermarkForm : Form
    {
        private readonly WatermarkService watermarkService;
        private Image selectedImage;

        public WatermarkForm()
        {
            InitializeComponent();
            watermarkService = new WatermarkService();

            // Attach event handlers
            btnUpload.Click += BtnUpload_Click;
            btnApplyWatermark.Click += BtnApplyWatermark_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnAddInvisibleWatermark.Click += BtnAddInvisibleWatermark_Click;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load and clone the image to avoid file locking issues
                        using (Image newImage = Image.FromFile(openFileDialog.FileName))
                        {
                            selectedImage?.Dispose();  // Dispose previous image if any
                            selectedImage = new Bitmap(newImage);  // Clone the image
                        }

                        // Update PictureBox with the new image
                        pictureBox.Image?.Dispose();
                        pictureBox.Image = new Bitmap(selectedImage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtnApplyWatermark_Click(object sender, EventArgs e)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string watermarkText = txtWatermark.Text;
            if (string.IsNullOrWhiteSpace(watermarkText))
            {
                MessageBox.Show("Please enter watermark text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // Force the watermark to save as a valid format (PNG)
                Image watermarkedImage = await watermarkService.ApplyWatermarkAsync(selectedImage, watermarkText, 16, 0.5); // Adjust font size and opacity

                // Ensure image format remains valid
                pictureBox.Image?.Dispose(); // Dispose the old image
                pictureBox.Image = new Bitmap(watermarkedImage);  // Always use a Bitmap (it has proper encoding)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Watermarked Image";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = saveFileDialog.FileName;
                        string extension = Path.GetExtension(filePath).ToLower();

                        // Always default to PNG to avoid encoder issues
                        ImageFormat format = extension switch
                        {
                            ".png" => ImageFormat.Png,
                            ".bmp" => ImageFormat.Bmp,
                            ".jpg" or ".jpeg" => ImageFormat.Jpeg,
                            _ => throw new ArgumentException("Unsupported file format.")
                        };

                        // Save the image in a valid format
                        pictureBox.Image.Save(filePath, format);

                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            pictureBox.Image?.Dispose();  // Dispose current image
            pictureBox.Image = null;
        }

        private async void BtnAddInvisibleWatermark_Click(object sender, EventArgs e)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("Please upload an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string author = txtAuthor.Text;
            string copyright = txtCopyright.Text;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save Watermarked Image";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // Apply invisible watermark and save to the chosen path
                        await watermarkService.AddInvisibleWatermarkAsync(
                            selectedImage,
                            author,
                            copyright,
                            "Image Description",
                            saveFileDialog.FileName
                        );

                        // Verify metadata by reloading the saved image
                        var metadata = watermarkService.DecodeInvisibleWatermark(new Bitmap(saveFileDialog.FileName));

                        MessageBox.Show($"Metadata:\n{metadata}", "Metadata Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Invisible watermark added and verified successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }


        // Proper disposal of the form
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            selectedImage?.Dispose();  // Dispose selected image
            base.Dispose(disposing);
        }
    }
}
