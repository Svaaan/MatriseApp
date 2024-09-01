using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class PlasmaChat : Form
    {
        private EncryptionHelper encryptionHelper;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream stream;
        private readonly object streamLock = new object();
        private Button btnShowPorts;

        public PlasmaChat()
        {
            InitializeComponent();
            encryptionHelper = new EncryptionHelper();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            
            btnShowPorts.Click += btnShowPorts_Click;
            Controls.Add(btnShowPorts);
        }

        // Button Click to Start Server
        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                LogMessage("Invalid port number.", "ERROR");
                return;
            }

            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                LogMessage("Server started. Waiting for connection...");
                await Task.Run(ServerListenLoop);
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting server: {ex.Message}", "ERROR");
            }
        }

        // Button Click to Connect to Server
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text;
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                LogMessage("Invalid IP address.", "ERROR");
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                LogMessage("Invalid port number.", "ERROR");
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ipAddress, port);
                stream = client.GetStream();
                LogMessage("Connected to server.");
                await SendPublicKeyAsync();
                await Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting to server: {ex.Message}", "ERROR");
            }
        }

        private async Task SendPublicKeyAsync()
        {
            try
            {
                var publicKeyBytes = encryptionHelper.GetPublicKey();
                await stream.WriteAsync(publicKeyBytes, 0, publicKeyBytes.Length);
                await stream.FlushAsync();
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending public key: {ex.Message}", "ERROR");
            }
        }

        private async Task ServerListenLoop()
        {
            while (true)
            {
                try
                {
                    using (var client = await server.AcceptTcpClientAsync())
                    using (var stream = client.GetStream())
                    {
                        byte[] publicKeyBytes = new byte[64]; // Adjust size if necessary
                        int bytesRead = await stream.ReadAsync(publicKeyBytes, 0, publicKeyBytes.Length);
                        if (bytesRead > 0)
                        {
                            encryptionHelper.SetPartnerPublicKey(publicKeyBytes.Take(bytesRead).ToArray());
                            LogMessage("Client connected successfully."); // Indicate client connection

                            using (var sr = new StreamReader(stream))
                            {
                                string encryptedMessage;
                                while ((encryptedMessage = await sr.ReadLineAsync()) != null)
                                {
                                    var decryptedMessage = encryptionHelper.DecryptMessage(Convert.FromBase64String(encryptedMessage));
                                    LogMessage($"Client: {decryptedMessage}");
                                }
                            }
                        }
                        else
                        {
                            LogMessage("No data received from client.", "ERROR");
                        }

                        LogMessage("Client disconnected."); // Indicate client disconnection
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Error in server loop: {ex.Message}", "ERROR");
                }
            }
        }

        private async Task ClientReceiveLoop()
        {
            try
            {
                byte[] publicKeyBytes = new byte[64]; // Adjust size if necessary
                int bytesRead = await stream.ReadAsync(publicKeyBytes, 0, publicKeyBytes.Length);
                if (bytesRead > 0)
                {
                    encryptionHelper.SetPartnerPublicKey(publicKeyBytes.Take(bytesRead).ToArray());
                    LogMessage("Connected to server successfully."); // Indicate server connection acknowledgment

                    using (var sr = new StreamReader(stream))
                    {
                        string encryptedMessage;
                        while (stream.CanRead && (encryptedMessage = await sr.ReadLineAsync()) != null)
                        {
                            var decryptedMessage = encryptionHelper.DecryptMessage(Convert.FromBase64String(encryptedMessage));
                            LogMessage($"Server: {decryptedMessage}");
                        }
                    }
                }
                else
                {
                    LogMessage("No data received from server.", "ERROR");
                }

                LogMessage("Disconnected from server."); // Indicate client disconnection
            }
            catch (IOException ex)
            {
                LogMessage($"I/O error in client receive loop: {ex.Message}", "ERROR");
            }
            catch (Exception ex)
            {
                LogMessage($"Error in client receive loop: {ex.Message}", "ERROR");
            }
        }

        // Button Click to Send Message
        public async void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (string.IsNullOrWhiteSpace(message))
            {
                LogMessage("Message cannot be empty.", "ERROR");
                return;
            }

            try
            {
                var encryptedMessage = encryptionHelper.EncryptMessage(message);
                using (var sw = new StreamWriter(stream) { AutoFlush = true })
                {
                    await sw.WriteLineAsync(Convert.ToBase64String(encryptedMessage));
                }
                LogMessage($"You: {message}");
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending message: {ex.Message}", "ERROR");
            }
        }

        private void LogMessage(string message, string level = "INFO")
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogMessage(message, level)));
                return;
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtChatLog.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        private void PlasmaChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (client != null)
                {
                    LogMessage("You have disconnected from the server."); // Notify user about disconnection
                    stream?.Close();
                    client.Close();
                }
                if (server != null)
                {
                    LogMessage("Server is shutting down."); // Notify user about server shutdown
                    server.Stop();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error closing connections: {ex.Message}", "ERROR");
            }
        }

        private void btnShowPorts_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new process to run the netstat command
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = "netstat";
                    process.StartInfo.Arguments = "-an"; // List all ports and their states
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    // Read the output
                    string output = process.StandardOutput.ReadToEnd();

                    process.WaitForExit();

                    // Show the result in a message box
                    MessageBox.Show(output, "Open Ports", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing netstat: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
