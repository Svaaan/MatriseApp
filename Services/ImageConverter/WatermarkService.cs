using ImageMagick;
using System;
using System.IO;

public class WatermarkService
{
    private readonly string watermarkImagePath;

    public WatermarkService()
    {
        // Update this path according to your project setup
        watermarkImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "watermark_image.png");
    }

    public void AddWatermark(MagickImage image, string watermarkText, int fontSize, double opacity)
    {
        if (!File.Exists(watermarkImagePath))
        {
            throw new FileNotFoundException("Watermark image file not found", watermarkImagePath);
        }

        using (var watermark = new MagickImage())
        {
            watermark.Read(watermarkImagePath);

            // For text watermark, create an image with text
            var text = new MagickImage(MagickColors.Transparent, image.Width, image.Height);
            var drawables = new Drawables()
                .FontPointSize(fontSize)
                .FillColor(MagickColors.White)
                .Text(image.Width / 2, image.Height / 2, watermarkText)
                .Gravity(Gravity.Center);
            drawables.Draw(text);

            // Set opacity
            text.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, opacity);

            // Composite text watermark on top of the image
            image.Composite(text, Gravity.Center, CompositeOperator.Over);
        }
    }
}
