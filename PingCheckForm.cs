using System;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class PingCheckForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private ToolTip toolTip;

        public PingCheckForm()
        {
            InitializeComponent();
            buttonPing.Click += ButtonPing_Click;
            buttonFetchIp.Click += ButtonFetchIp_Click;

            // Initialize ToolTip
            toolTip = new ToolTip();

            // Set tooltip text for the Fetch IP button
            toolTip.SetToolTip(buttonFetchIp, "Fetches your public IP address from online service: https://api.ipify.org?format=text");
        }

        private async void ButtonPing_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxIpAddress.Text;

            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                MessageBox.Show("Please enter an IP address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            labelResult.Text = "Pinging...";

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(ipAddress);

                    if (reply.Status == IPStatus.Success)
                    {
                        labelResult.Text = $"Reply from {reply.Address}: Time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}";
                    }
                    else
                    {
                        labelResult.Text = $"Ping failed: {reply.Status}";
                    }
                }
            }
            catch (Exception ex)
            {
                labelResult.Text = $"Error: {ex.Message}";
            }
        }

        private async void ButtonFetchIp_Click(object sender, EventArgs e)
        {
            string ipAddress = await GetPublicIpAddressAsync();
            if (ipAddress != null)
            {
                textBoxIpAddress.Text = ipAddress;
            }
            else
            {
                MessageBox.Show("Unable to fetch IP address. Please check your internet connection.", "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> GetPublicIpAddressAsync()
        {
            try
            {
                // Fetch the public IP address from a reliable service
                HttpResponseMessage response = await httpClient.GetAsync("https://api.ipify.org?format=text");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching IP address: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void labelResult_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelResult_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxIpAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
