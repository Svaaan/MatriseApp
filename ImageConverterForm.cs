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

            imageUploadService = new ImageUploadService();
            imageConversionService = new ImageConversionService();
     
            buttonUpload.Click += ButtonUpload_Click;
            buttonConvert.Click += ButtonConvert_Click;
   
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
            pictureBox.Image = uploadedImage.ToBitmap();
        }
    }
}
