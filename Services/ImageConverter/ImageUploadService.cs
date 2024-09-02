using System;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;

namespace Sp00ksy.Services.ImageConverter
{
    public class ImageUploadService
    {
        public MagickImage UploadImage(out Bitmap previewImage)
        {
            previewImage = null;

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

                    var uploadedImage = new MagickImage(filePath, settings);

                    // Resize to a reasonable preview size
                    uploadedImage.Resize(new MagickGeometry(256, 256)
                    {
                        IgnoreAspectRatio = false
                    });

                    // Convert to Bitmap for preview
                    previewImage = uploadedImage.ToBitmap();

                    return uploadedImage;
                }
            }

            return null;
        }
    }
}
