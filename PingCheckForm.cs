using Matrise.Services.PingCheck;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrise
{
    public partial class PingCheckForm : Form
    {
        private readonly PingService pingService;
        private readonly IpFetchService ipFetchService;
        private readonly ToolTipService toolTipService;

        public PingCheckForm()
        {
            InitializeComponent();
            pingService = new PingService();
            ipFetchService = new IpFetchService();
            toolTipService = new ToolTipService();

            buttonPing.Click += ButtonPing_Click;
            buttonFetchIp.Click += ButtonFetchIp_Click;

            toolTipService.SetToolTip(buttonFetchIp, "Fetches your public IP address from online service: https://api.ipify.org?format=text");
        }

        private async void ButtonPing_Click(object sender, EventArgs e)
        {
            string ipAddress = textBoxIpAddress.Text;

            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                MessageBox.Show("Please enter an IP address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            groupBoxPingResults.Visible = false;
            labelAddress.Text = "Address:";
            labelRoundtripTime.Text = "Roundtrip Time:";
            labelTTL.Text = "TTL:";
            labelBufferSize.Text = "Buffer Size:";
            labelPingSuccessful.Text = "Ping Successful:";

            PingResult pingResult = await pingService.PingAsync(ipAddress);

            if (pingResult.IsSuccess)
            {
                labelAddress.Text = $"Address ({pingResult.AddressType}): {pingResult.Address}";
                labelRoundtripTime.Text = $"Roundtrip Time: {pingResult.RoundtripTime}ms";
                labelTTL.Text = $"TTL: {pingResult.Ttl}";
                labelBufferSize.Text = $"Buffer Size: {pingResult.BufferSize} bytes";
                labelPingSuccessful.Text = $"Ping Successful: {pingResult.IsSuccess}";

                Color textColor = Color.Green;
                labelAddress.ForeColor = textColor;
                labelRoundtripTime.ForeColor = textColor;
                labelTTL.ForeColor = textColor;
                labelBufferSize.ForeColor = textColor;
                labelPingSuccessful.ForeColor = textColor;

                groupBoxPingResults.Visible = true;
            }
            else if (!string.IsNullOrEmpty(pingResult.ErrorMessage))
            {
                labelAddress.Text = $"Error: {pingResult.ErrorMessage}";
                Color textColor = Color.Red;
                labelAddress.ForeColor = textColor;

                groupBoxPingResults.Visible = true;
            }
            else
            {
                labelAddress.Text = $"Ping failed: {pingResult.Status}";
                Color textColor = Color.Red;
                labelAddress.ForeColor = textColor;

                groupBoxPingResults.Visible = true;
            }
        }

        private async void ButtonFetchIp_Click(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = await ipFetchService.GetPublicIpAddressAsync();
                textBoxIpAddress.Text = ipAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
