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

            // Initially hide the GroupBox
            groupBoxPingResults.Visible = false;
            labelAddress.Text = "Address:";
            labelRoundtripTime.Text = "Roundtrip Time:";
            labelTTL.Text = "TTL:";
            labelBufferSize.Text = "Buffer Size:";
            labelPingSuccessful.Text = "Ping Successful:";

            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(ipAddress);

                    if (reply.Status == IPStatus.Success)
                    {
                        // Collecting additional information
                        string replyAddress = reply.Address.ToString();
                        long roundtripTime = reply.RoundtripTime;
                        int ttl = reply.Options.Ttl;
                        bool isPingSuccessful = reply.Status == IPStatus.Success;
                        string buffer = reply.Buffer.Length > 0 ? BitConverter.ToString(reply.Buffer) : "No buffer";
                        string addressType = reply.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? "IPv4" : "IPv6";

                        // Setting label texts
                        labelAddress.Text = $"Address ({addressType}): {replyAddress}";
                        labelRoundtripTime.Text = $"Roundtrip Time: {roundtripTime}ms";
                        labelTTL.Text = $"TTL: {ttl}";
                        labelBufferSize.Text = $"Buffer Size: {reply.Buffer.Length} bytes";
                        labelPingSuccessful.Text = $"Ping Successful: {isPingSuccessful}";

                        // Color coding
                        Color textColor = isPingSuccessful ? Color.Green : Color.Red;
                        labelAddress.ForeColor = textColor;
                        labelRoundtripTime.ForeColor = textColor;
                        labelTTL.ForeColor = textColor;
                        labelBufferSize.ForeColor = textColor;
                        labelPingSuccessful.ForeColor = textColor;

                        // Show the GroupBox
                        groupBoxPingResults.Visible = true;
                    }
                    else
                    {
                        labelAddress.Text = $"Ping failed: {reply.Status}";
                        labelRoundtripTime.Text = "";
                        labelTTL.Text = "";
                        labelBufferSize.Text = "";
                        labelPingSuccessful.Text = "";

                        // Set color to red for failure
                        Color textColor = Color.Red;
                        labelAddress.ForeColor = textColor;
                        labelRoundtripTime.ForeColor = textColor;
                        labelTTL.ForeColor = textColor;
                        labelBufferSize.ForeColor = textColor;
                        labelPingSuccessful.ForeColor = textColor;

                        // Show the GroupBox
                        groupBoxPingResults.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                labelAddress.Text = $"Error: {ex.Message}";
                labelRoundtripTime.Text = "";
                labelTTL.Text = "";
                labelBufferSize.Text = "";
                labelPingSuccessful.Text = "";

                // Set color to red for error
                Color textColor = Color.Red;
                labelAddress.ForeColor = textColor;

                // Show the GroupBox
                groupBoxPingResults.Visible = true;
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

        private void groupBoxPingResults_Enter(object sender, EventArgs e)
        {

        }
    }
}
