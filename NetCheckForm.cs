using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class NetCheckForm : Form
    {
        private const int TestDuration = 10000; // 10 seconds in milliseconds
        private const int UpdateInterval = 100; // Update interval for progress bars in milliseconds
        private const int MaxNumberOfTests = 10; // Maximum number of tests

        public NetCheckForm()
        {
            InitializeComponent();
        }

        private async void SpeedTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfTests = (int)numberOfTestsUpDown.Value; // Get the selected number of tests
                if (numberOfTests < 1 || numberOfTests > MaxNumberOfTests)
                {
                    MessageBox.Show($"Please select a number of tests between 1 and {MaxNumberOfTests}.", "Invalid Number of Tests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                speedTestButton.Enabled = false; // Disable button to prevent multiple clicks
                downloadSpeedLabel.Text = "Measuring download speed...";
                uploadSpeedLabel.Text = "Measuring upload speed...";
                downloadProgressBar.Value = 0;
                uploadProgressBar.Value = 0;

                // Prepare to collect test results
                var downloadSpeeds = new List<double>();
                var uploadSpeeds = new List<double>();

                for (int i = 0; i < numberOfTests; i++)
                {
                    await RunSpeedTestAsync(downloadSpeeds, uploadSpeeds);

                    // Wait for a short period before the next test (to avoid overlap)
                    await Task.Delay(1000); // 1 second delay between tests
                }

                // Calculate and display average results
                var avgDownloadSpeed = downloadSpeeds.Average();
                var avgUploadSpeed = uploadSpeeds.Average();
                downloadSpeedLabel.Text = $"Average Download Speed: {avgDownloadSpeed:F2} Mbps";
                uploadSpeedLabel.Text = $"Average Upload Speed: {avgUploadSpeed:F2} Mbps";

                speedTestButton.Enabled = true; // Re-enable the button
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Speed Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                speedTestButton.Enabled = true; // Re-enable the button in case of error
            }
        }

        private async Task RunSpeedTestAsync(List<double> downloadSpeeds, List<double> uploadSpeeds)
        {
            // Run the speed test
            var startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalMilliseconds < TestDuration)
            {
                var speeds = await MeasureNetworkSpeedsAsync();

                // Update progress bars
                downloadProgressBar.Value = (int)Math.Min(speeds.downloadSpeed, 100); // Assuming progress bar max is 100
                uploadProgressBar.Value = (int)Math.Min(speeds.uploadSpeed, 100); // Assuming progress bar max is 100

                // Update labels with current speeds
                downloadSpeedLabel.Text = $"Download Speed: {speeds.downloadSpeed:F2} Mbps";
                uploadSpeedLabel.Text = $"Upload Speed: {speeds.uploadSpeed:F2} Mbps";

                // Collect results
                downloadSpeeds.Add(speeds.downloadSpeed);
                uploadSpeeds.Add(speeds.uploadSpeed);

                // Wait before updating
                await Task.Delay(UpdateInterval);
            }
        }

        private async Task<(double downloadSpeed, double uploadSpeed)> MeasureNetworkSpeedsAsync()
        {
            // Construct the path to speedtest.exe relative to the application's base directory
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string speedtestCliPath = Path.Combine(baseDirectory, "Resources", "speedtest.exe");

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
