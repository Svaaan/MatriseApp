using ImageMagick;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

public class WatermarkService
{
    public void AddWatermark(MagickImage image, string watermarkText, int fontSize, double opacity)
    {
        // Dynamic font size scaling based on image width
        int dynamicFontSize = (int)(image.Width * 0.05); // 5% of the image width
        fontSize = dynamicFontSize > fontSize ? dynamicFontSize : fontSize;

        // Set padding to ensure the watermark stays inside the image boundaries
        int padding = (int)(image.Width * 0.02); // 2% of the image width

        using (var textWatermark = new MagickImage(MagickColors.Transparent, image.Width, image.Height))
        {
            var drawables = new Drawables()
                .FontPointSize(fontSize)
                .FillColor(new MagickColor(255, 255, 255, (byte)(Quantum.Max * opacity))) // White with opacity
                .StrokeColor(MagickColors.Transparent)
                .TextAlignment(TextAlignment.Center);

            // Calculate number of rows and columns for watermarks
            int numRows = 2;  // 2 rows
            int numCols = 5;  // 5 columns

            // Calculate spacing between watermarks based on image size and number of rows/columns
            int tileSpacingX = (image.Width - 2 * padding) / numCols;  // Horizontal space between watermarks
            int tileSpacingY = (image.Height - 2 * padding) / numRows; // Vertical space between watermarks

            // Adjust spacing to ensure watermarks fit within the image boundaries
            tileSpacingX = Math.Max(tileSpacingX, fontSize);
            tileSpacingY = Math.Max(tileSpacingY, fontSize);

            // Loop to place watermarks
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // Calculate the x and y positions for each watermark
                    int xPos = padding + (col * tileSpacingX);
                    int yPos = padding + (row * tileSpacingY);

                    // Ensure watermark is within the image boundaries
                    if (xPos + fontSize < image.Width - padding && yPos + fontSize < image.Height - padding)
                    {
                        drawables.Text(xPos, yPos, watermarkText);
                    }
                }
            }

            // Draw all watermarks onto the transparent image
            drawables.Draw(textWatermark);

            // Composite the watermarked transparent image over the original image
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
