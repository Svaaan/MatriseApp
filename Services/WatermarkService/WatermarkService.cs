using ImageMagick;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

public class WatermarkService
{
    public void AddWatermark(MagickImage image, string watermarkText, int fontSize, double opacity)
    {
        using (var textWatermark = new MagickImage(MagickColors.Transparent, image.Width, image.Height))
        {
            var drawables = new Drawables()
                .FontPointSize(fontSize)
                .FillColor(MagickColors.White)
                .Text(image.Width / 2, image.Height / 2, watermarkText)
                .Gravity(Gravity.Center);
            drawables.Draw(textWatermark);

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
}
