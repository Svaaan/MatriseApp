using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class NetCheckForm : Form
    {
        private const double MaxSpeed = 100; // Maximum expected speed in Mbps for scaling progress bars

        public NetCheckForm()
        {
            InitializeComponent();
            speedTestButton.Text = "Check Download Speed"; // Set button text
            speedTestButton.Click += SpeedTestButton_Click; // Add click event for the button
        }

        private async void SpeedTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                double downloadSpeed = await MeasureDownloadSpeedAsync();
                MessageBox.Show($"Download Speed: {downloadSpeed:F2} Mbps", "Speed Test Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Speed Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<double> MeasureDownloadSpeedAsync()
        {
            // Endpoint provided by Fast.com for testing purposes
            string testUrl = "https://speedtest.fast.com/api/v1/download?https=true&token=YOUR_TOKEN_HERE&urlCount=5"; // Replace with actual Fast.com endpoint if available

            using (HttpClient client = new HttpClient())
            {
                var stopwatch = Stopwatch.StartNew();

                HttpResponseMessage response = await client.GetAsync(testUrl, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                var buffer = new byte[8192];
                long totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                stopwatch.Stop();
                double downloadTimeInSeconds = stopwatch.Elapsed.TotalSeconds;
                double downloadSpeedMbps = (totalBytesRead * 8) / (1024 * 1024) / downloadTimeInSeconds;

                return downloadSpeedMbps;
            }
        }
    }
}
