using ImageMagick;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

public class WatermarkService
{
    public void AddWatermark(MagickImage image, string watermarkText, int fontSize, double opacity)
    {
        const int maxTextLength = 13;

        if (watermarkText.Length > maxTextLength)
        {
            throw new ArgumentException($"Watermark text has a {maxTextLength} characters limit.");
        }

        int padding = (int)(image.Width * 0.02);

        using (var textWatermark = new MagickImage(MagickColors.Transparent, image.Width, image.Height))
        {
            var drawables = new Drawables()
                .FontPointSize(fontSize)
                .FillColor(new MagickColor(255, 255, 255, (byte)(Quantum.Max * opacity)))
                .StrokeColor(MagickColors.Transparent)
                .TextAlignment(TextAlignment.Center);

            int numRows = 4;
            int numCols = 5;

            int tileSpacingX = (image.Width - 2 * padding) / numCols;
            int tileSpacingY = (image.Height - 2 * padding) / numRows;

            tileSpacingX = Math.Max(tileSpacingX, 1);
            tileSpacingY = Math.Max(tileSpacingY, 1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    int xPos = padding + (col * tileSpacingX) + (tileSpacingX / 2);
                    int yPos = padding + (row * tileSpacingY) + (tileSpacingY / 2);

                    if (xPos < image.Width - padding && yPos < image.Height - padding)
                    {
                        drawables.Text(xPos, yPos, watermarkText);
                    }
                }
            }

            drawables.Draw(textWatermark);
            image.Composite(textWatermark, Gravity.Northwest, CompositeOperator.Over);
        }
    }


    public async Task<Image> ApplyWatermarkAsync(Image selectedImage, string watermarkText, int fontSize, double opacity)
    {
        using (var magickImage = new MagickImage(ImageToByteArray(selectedImage)))
        {
            AddWatermark(magickImage, watermarkText, fontSize, opacity);
            return ByteArrayToImage(magickImage.ToByteArray());
        }
    }


    private byte[] ImageToByteArray(System.Drawing.Image image)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }

    private System.Drawing.Image ByteArrayToImage(byte[] byteArray)
    {
        using (var ms = new MemoryStream(byteArray))
        {
            return System.Drawing.Image.FromStream(ms);
        }
    }

    // Method to embed invisible watermark (metadata)
    public async Task AddInvisibleWatermarkAsync(Image selectedImage, string author, string copyright, string description)
    {
        using (var magickImage = new MagickImage(ImageToByteArray(selectedImage)))
        {
            // Adding metadata as invisible watermark
            magickImage.SetAttribute("Author", author);
            magickImage.SetAttribute("Copyright", copyright);
            magickImage.SetAttribute("Description", description);

            // Save the image with metadata
            var byteArray = magickImage.ToByteArray();
            File.WriteAllBytes("path_to_save_image_with_metadata", byteArray);

            await Task.CompletedTask;
        }
    }

    public string DecodeInvisibleWatermark(Image selectedImage)
    {
        try
        {
            using (var magickImage = new MagickImage(ImageToByteArray(selectedImage)))
            {
                // Retrieve metadata attributes
                string author = magickImage.GetAttribute("Author") ?? "N/A";
                string copyright = magickImage.GetAttribute("Copyright") ?? "N/A";
                string description = magickImage.GetAttribute("Description") ?? "N/A";

                // Format the result
                return $"Author: {author}, Copyright: {copyright}, Description: {description}";
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return $"An error occurred while retrieving metadata: {ex.Message}";
        }
    }
}
