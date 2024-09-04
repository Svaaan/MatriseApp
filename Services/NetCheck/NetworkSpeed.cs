namespace Sp00ksy.Services.NetCheck
{
    public class NetworkSpeed
    {
        public double DownloadSpeed { get; }
        public double UploadSpeed { get; }

        public NetworkSpeed(double downloadSpeed, double uploadSpeed)
        {
            DownloadSpeed = downloadSpeed;
            UploadSpeed = uploadSpeed;
        }
    }
}
