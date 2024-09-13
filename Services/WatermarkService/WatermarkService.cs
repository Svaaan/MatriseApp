using ImageMagick;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

public class WatermarkService
{
    public void AddWatermark(MagickImage image, string watermarkText, int fontSize, double opacity)
    {
        using (var textWatermark = new MagickImage(MagickColors.Transparent, image.Width, image.Height))
        {
            // Set the font size
            fontSize = 24;

            // Create drawables with increased font size
            var drawables = new Drawables()
                .FontPointSize(fontSize) // Increase the font size here
                .FillColor(MagickColors.White)
                .TextAlignment(TextAlignment.Center);

            // Add text at specific positions
            drawables
                .Gravity(Gravity.Northwest)
                .Text(10, 10, watermarkText)  // Top-left corner

                .Gravity(Gravity.Northeast)
                .Text(image.Width - 10, 10, watermarkText)  // Top-right corner

                .Gravity(Gravity.Southwest)
                .Text(10, image.Height - 10, watermarkText)  // Bottom-left corner

                .Gravity(Gravity.Southeast)
                .Text(image.Width - 10, image.Height - 10, watermarkText)  // Bottom-right corner

                .Gravity(Gravity.Center)
                .Text(image.Width / 2, image.Height / 2, watermarkText);  // Center

            drawables.Draw(textWatermark);

            // Apply opacity to the text watermark
            textWatermark.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, opacity);
            image.Composite(textWatermark, Gravity.Center, CompositeOperator.Over);
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

    // Method to extract invisible watermark (metadata)
    public string DecodeInvisibleWatermark(Image selectedImage)
    {
        using (var magickImage = new MagickImage(ImageToByteArray(selectedImage)))
        {
            string author = magickImage.GetAttribute("Author");
            string copyright = magickImage.GetAttribute("Copyright");
            string description = magickImage.GetAttribute("Description");

            return $"Author: {author}, Copyright: {copyright}, Description: {description}";
        }
    }
}
