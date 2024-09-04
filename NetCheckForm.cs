using Matrise.Services.NetCheck;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrise
{
    public partial class NetCheckForm : Form
    {
        private const int MaxNumberOfTests = 10;

        private readonly SpeedTestService speedTestService;
        private readonly SpeedTestResultAggregator resultAggregator;

        public NetCheckForm()
        {
            InitializeComponent();
            speedTestService = new SpeedTestService();
            resultAggregator = new SpeedTestResultAggregator();
        }

        private async void SpeedTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                int numberOfTests = (int)numberOfTestsUpDown.Value;
                if (numberOfTests < 1 || numberOfTests > MaxNumberOfTests)
                {
                    MessageBox.Show($"Please select a number of tests between 1 and {MaxNumberOfTests}.", "Invalid Number of Tests", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                speedTestButton.Enabled = false;
                statusLabel.Text = "Starting speed tests...";
                resultsTextBox.Clear();

                var downloadSpeeds = new List<double>();
                var uploadSpeeds = new List<double>();

                for (int i = 0; i < numberOfTests; i++)
                {
                    statusLabel.Text = $"Running test {i + 1} of {numberOfTests}...";
                    await speedTestService.RunSpeedTestAsync(downloadSpeeds, uploadSpeeds);

                    // Get the current timestamp
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // Log the results of each test with timestamp
                    resultsTextBox.AppendText($"{timestamp} - Test {i + 1}: Download Speed: {downloadSpeeds[^1]:F2} Mbps, Upload Speed: {uploadSpeeds[^1]:F2} Mbps{Environment.NewLine}");

                    await Task.Delay(1000); // Add a delay between tests if necessary
                }

                var avgDownloadSpeed = resultAggregator.CalculateAverageDownloadSpeed(downloadSpeeds);
                var avgUploadSpeed = resultAggregator.CalculateAverageUploadSpeed(uploadSpeeds);

                downloadSpeedLabel.Text = $"Average Download Speed: {avgDownloadSpeed:F2} Mbps";
                uploadSpeedLabel.Text = $"Average Upload Speed: {avgUploadSpeed:F2} Mbps";

                statusLabel.Text = "Speed test completed.";
                speedTestButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Speed Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Error during speed test.";
                speedTestButton.Enabled = true;
            }
        }
    }
    
}
