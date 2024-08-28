using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class NetCheckForm : Form
    {
        public NetCheckForm()
        {
            InitializeComponent();
            speedTestButton.Text = "Check Network Speed"; // Set button text
            speedTestButton.Click += SpeedTestButton_Click; // Add click event for the button
        }

        private async void SpeedTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                speedTestButton.Enabled = false; // Disable button to prevent multiple clicks
                downloadSpeedLabel.Text = "Measuring download speed...";
                uploadSpeedLabel.Text = "Measuring upload speed...";
                downloadProgressBar.Value = 0;
                uploadProgressBar.Value = 0;

                var speeds = await MeasureNetworkSpeedsAsync();

                downloadSpeedLabel.Text = $"Download Speed: {speeds.downloadSpeed:F2} Mbps";
                uploadSpeedLabel.Text = $"Upload Speed: {speeds.uploadSpeed:F2} Mbps";
                downloadProgressBar.Value = (int)Math.Min(speeds.downloadSpeed, 100); // Assuming progress bar max is 100
                uploadProgressBar.Value = (int)Math.Min(speeds.uploadSpeed, 100);     // Assuming progress bar max is 100

                speedTestButton.Enabled = true; // Re-enable the button
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Speed Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                speedTestButton.Enabled = true; // Re-enable the button in case of error
            }
        }

        private async Task<(double downloadSpeed, double uploadSpeed)> MeasureNetworkSpeedsAsync()
        {
            // Construct the path to speedtest.exe relative to the project's directory
            string projectRootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string speedtestCliPath = Path.Combine(projectRootPath, "speedtest.exe");

            // Check if the file exists to avoid runtime errors
            if (!File.Exists(speedtestCliPath))
            {
                throw new FileNotFoundException("Speedtest executable not found.", speedtestCliPath);
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = speedtestCliPath,
                Arguments = "--format=json", // Run the CLI with JSON output for easier parsing
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                process.WaitForExit();

                // Parse the JSON output to extract download and upload speeds
                var result = System.Text.Json.JsonDocument.Parse(output);
                double downloadSpeedMbps = result.RootElement.GetProperty("download").GetProperty("bandwidth").GetDouble() * 8 / 1_000_000; // Convert from bytes/s to Mbps
                double uploadSpeedMbps = result.RootElement.GetProperty("upload").GetProperty("bandwidth").GetDouble() * 8 / 1_000_000; // Convert from bytes/s to Mbps

                return (downloadSpeedMbps, uploadSpeedMbps);
            }
        }
    }
}
