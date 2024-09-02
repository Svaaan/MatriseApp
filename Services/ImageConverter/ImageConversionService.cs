using System;
using System.IO;
using System.Windows.Forms;
using ImageMagick;

namespace Sp00ksy.Services.ImageConverter
{
    public class ImageConversionService
    {
        public void ConvertAndSaveImage(MagickImage uploadedImage)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|WebP Image|*.webp|ICO Image|*.ico";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    if (Path.GetExtension(savePath).ToLower() == ".ico")
                    {
                        SaveAsIcon(uploadedImage, savePath);
                    }
                    else
                    {
                        uploadedImage.Write(savePath);
                    }

                    MessageBox.Show("Image converted and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveAsIcon(MagickImage sourceImage, string savePath)
        {
            using (var iconCollection = new MagickImageCollection())
            {
                AddImageToIconCollection(sourceImage, iconCollection, 16);
                AddImageToIconCollection(sourceImage, iconCollection, 32);
                AddImageToIconCollection(sourceImage, iconCollection, 48);
                AddImageToIconCollection(sourceImage, iconCollection, 64);
                AddImageToIconCollection(sourceImage, iconCollection, 128);

                iconCollection.Write(savePath);
            }
        }

        private void AddImageToIconCollection(MagickImage sourceImage, MagickImageCollection iconCollection, int size)
        {
            var iconImage = sourceImage.Clone();
            iconImage.Resize(size, size);
            iconCollection.Add(iconImage);
        }
    }
}
