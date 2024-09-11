using System;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;
using Matrise.Services.ImageConverter;

namespace Matrise
{
    public partial class ImageConverterForm : Form
    {
        private MagickImage uploadedImage;
        private readonly ImageUploadService imageUploadService;
        private readonly ImageConversionService imageConversionService;
        

        public ImageConverterForm()
        {
            InitializeComponent();
            // Initialize services
            imageUploadService = new ImageUploadService();
            imageConversionService = new ImageConversionService();
             // Initialize WatermarkService

            // Set up event handlers
            buttonUpload.Click += ButtonUpload_Click;
            buttonConvert.Click += ButtonConvert_Click;
            //buttonApplyWatermark.Click += ButtonApplyWatermark_Click; // Add event handler for apply watermark
            //buttonWatermark.Click += ButtonWatermark_Click; // Add event handler for watermark button
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            Bitmap previewImage;
            uploadedImage = imageUploadService.UploadImage(out previewImage);

            if (uploadedImage != null)
            {
                pictureBox.Image = previewImage; // Display the preview image
            }
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            if (uploadedImage == null)
            {
                MessageBox.Show("Please upload an image first.", "No Image Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            imageConversionService.ConvertAndSaveImage(uploadedImage);
        }

        private void ButtonApplyWatermark_Click(object sender, EventArgs e)
        {
            if (uploadedImage == null)
            {
                MessageBox.Show("Please upload an image first.", "No Image Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve user input for watermarking
           // string watermarkText = textBoxWatermark.Text;
            //int fontSize = (int)numericUpDownFontSize.Value;
          //  double opacity = trackBarOpacity.Value / 100.0;

            // Apply watermark using WatermarkService
            //watermarkService.AddWatermark(uploadedImage, watermarkText, fontSize: fontSize, opacity: opacity);

            // Update the PictureBox with the watermarked image
            pictureBox.Image = uploadedImage.ToBitmap();
        }

        private void ButtonWatermark_Click(object sender, EventArgs e)
        {
            // Handle the watermark button click event to show watermark settings
            // This could show/hide the watermark settings controls or another form
           // panelWatermarkSettings.Visible = !panelWatermarkSettings.Visible;
        }
    }
}
