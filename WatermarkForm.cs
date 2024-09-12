using System;
using System.Drawing;
using System.IO;
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

            // Attach event handlers here
            btnUpload.Click += BtnUpload_Click;
            btnApplyWatermark.Click += BtnApplyWatermark_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
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
                        selectedImage = Image.FromFile(openFileDialog.FileName);
                        pictureBox.Image = selectedImage;
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

                Image watermarkedImage = await watermarkService.ApplyWatermarkAsync(selectedImage, watermarkText, 24, 0.5); // Adjust font size and opacity as needed

                pictureBox.Image = watermarkedImage;
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
                saveFileDialog.DefaultExt = "jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Image saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
