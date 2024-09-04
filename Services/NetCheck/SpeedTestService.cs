using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Matrise.Services.NetCheck
{
    public class SpeedTestService
    {
        private const int TestDuration = 10000; // 10 seconds in milliseconds
        private const int UpdateInterval = 100; // Update interval for progress bars in milliseconds

        public async Task<NetworkSpeed> MeasureNetworkSpeedsAsync()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string speedtestCliPath = Path.Combine(baseDirectory, "Resources", "speedtest.exe");

            if (!File.Exists(speedtestCliPath))
            {
                throw new FileNotFoundException("Speedtest executable not found.", speedtestCliPath);
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = speedtestCliPath,
                Arguments = "--format=json",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                var result = System.Text.Json.JsonDocument.Parse(output);
                double downloadSpeedMbps = result.RootElement.GetProperty("download").GetProperty("bandwidth").GetDouble() * 8 / 1_000_000; // Convert from bytes/s to Mbps
                double uploadSpeedMbps = result.RootElement.GetProperty("upload").GetProperty("bandwidth").GetDouble() * 8 / 1_000_000; // Convert from bytes/s to Mbps

                return new NetworkSpeed(downloadSpeedMbps, uploadSpeedMbps);
            }
        }

        public async Task RunSpeedTestAsync(List<double> downloadSpeeds, List<double> uploadSpeeds)
        {
            var startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < TestDuration)
            {
                var speeds = await MeasureNetworkSpeedsAsync();

                downloadSpeeds.Add(speeds.DownloadSpeed);
                uploadSpeeds.Add(speeds.UploadSpeed);

                await Task.Delay(UpdateInterval);
            }
        }
    }
}
