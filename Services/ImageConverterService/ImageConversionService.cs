using System;
using System.IO;
using System.Windows.Forms;
using ImageMagick;

namespace Matrise.Services.ImageConverter
{
    public class ImageConversionService
    {
        public void ConvertAndSaveImage(MagickImage uploadedImage)
        {
            if (uploadedImage == null)
            {
                MessageBox.Show("No image has been uploaded for conversion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|WebP Image|*.webp|ICO Image|*.ico|AVIF Image|*.avif";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = saveFileDialog.FileName;
                        string extension = Path.GetExtension(savePath).ToLower();

                        if (extension == ".ico")
                        {
                            SaveAsIcon(uploadedImage, savePath);
                        }
                        else
                        {
                            // Set quality or compression level based on the format
                            if (extension == ".jpg" || extension == ".jpeg")
                            {
                                uploadedImage.Quality = 90; // Set JPEG quality
                            }
                            else if (extension == ".webp")
                            {
                                uploadedImage.Settings.SetDefine(MagickFormat.WebP, "quality", "80"); // Set WebP quality
                            }
                            else if (extension == ".avif")
                            {
                                uploadedImage.Settings.SetDefine(MagickFormat.Avif, "quality", "80"); // Set AVIF quality
                            }

                            // Write the image without resizing
                            uploadedImage.Write(savePath);
                        }

                        MessageBox.Show("Image converted and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during image conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveAsIcon(MagickImage sourceImage, string savePath)
        {
            using (var iconCollection = new MagickImageCollection())
            {
                // Specify sizes needed for ICO format
                int[] sizes = { 16, 32, 48, 64, 128, 256 }; // Adjust sizes as needed

                foreach (var size in sizes)
                {
                    AddImageToIconCollection(sourceImage, iconCollection, size);
                }

                iconCollection.Write(savePath);
            }
        }

        private void AddImageToIconCollection(MagickImage sourceImage, MagickImageCollection iconCollection, int size)
        {
            var iconImage = sourceImage.Clone();

            // Only resize for specific sizes in ICO format
            iconImage.Resize(size, size);

            iconCollection.Add(iconImage);
        }
    }
}
