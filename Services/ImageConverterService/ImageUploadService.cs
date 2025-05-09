﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;

namespace Matrise.Services.ImageConverter
{
    public class ImageUploadService
    {
        public MagickImage UploadImage(out Bitmap previewImage)
        {
            previewImage = null;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.avif;*.webp;*.png;*.jpeg;*.jpg";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        // Load the image without resizing to retain original dimensions
                        var uploadedImage = new MagickImage(filePath);

                        // Create a separate resized copy for preview
                        var previewImageCopy = uploadedImage.Clone();
                        previewImageCopy.Resize(new MagickGeometry(256, 256)
                        {
                            IgnoreAspectRatio = false
                        });

                        // Convert the resized copy to Bitmap for preview
                        previewImage = previewImageCopy.ToBitmap();

                        // Return the original image without modification
                        return uploadedImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while uploading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
