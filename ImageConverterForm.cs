using System;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;
using Sp00ksy.Services.ImageConverter; // Import the services

namespace Sp00ksy
{
    public partial class ImageConverterForm : Form
    {
        private MagickImage uploadedImage;
        private readonly ImageUploadService imageUploadService;
        private readonly ImageConversionService imageConversionService;

        public ImageConverterForm()
        {
            InitializeComponent();
            buttonUpload.Text = "Upload Image";
            buttonConvert.Text = "Convert Image";
            buttonUpload.Click += ButtonUpload_Click;
            buttonConvert.Click += ButtonConvert_Click;

            // Initialize services
            imageUploadService = new ImageUploadService();
            imageConversionService = new ImageConversionService();
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
    }
}
