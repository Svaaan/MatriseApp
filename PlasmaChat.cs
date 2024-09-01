using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class PlasmaChat : Form
    {
        private TcpClient client;
        private TcpListener server;
        private NetworkStream clientStream; // Separate client stream
        private StreamWriter clientWriter;
        private StreamReader clientReader;
        private TcpClient serverClient; // The client connection for server-initiated clients
        private NetworkStream serverClientStream; // Stream for the server-initiated client
        private StreamWriter serverClientWriter;
        private readonly object streamLock = new object();
        private Button btnShowPorts;

        public PlasmaChat()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            btnShowPorts = new Button
            {
                Text = "Show Open Ports",
                Location = new Point(10, 10) // Adjust location as needed
            };

            btnShowPorts.Click += btnShowPorts_Click;
            Controls.Add(btnShowPorts);
        }

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
                clientStream = client.GetStream();
                clientWriter = new StreamWriter(clientStream) { AutoFlush = true };
                clientReader = new StreamReader(clientStream);
                LogMessage("Connected to server.");
                await Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting to server: {ex.Message}", "ERROR");
            }
        }

        private async Task ServerListenLoop()
        {
            while (true)
            {
                try
                {
                    serverClient = await server.AcceptTcpClientAsync();
                    serverClientStream = serverClient.GetStream();
                    serverClientWriter = new StreamWriter(serverClientStream) { AutoFlush = true };
                    var serverClientReader = new StreamReader(serverClientStream);
                    LogMessage("Client connected successfully.");

                    // Run client handling in a separate task
                    _ = Task.Run(async () =>
                    {
                        string message;
                        while ((message = await serverClientReader.ReadLineAsync()) != null)
                        {
                            LogMessage($"Client: {message}");
                            // Echo message back to client and log it
                            await serverClientWriter.WriteLineAsync($"Server received: {message}");
                            LogMessage($"Server sent: Server received: {message}");
                        }
                        LogMessage("Client disconnected.");
                        serverClient.Close();
                    });
                }
                catch (IOException ex)
                {
                    LogMessage($"I/O error in server loop: {ex.Message}", "ERROR");
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
                string message;
                while ((message = await clientReader.ReadLineAsync()) != null)
                {
                    LogMessage($"Server: {message}");
                    LogMessage("Client received message.");
                }
            }
            catch (IOException ex)
            {
                LogMessage($"I/O error in client receive loop: {ex.Message}", "ERROR");
            }
            catch (ObjectDisposedException ex)
            {
                LogMessage($"Stream closed unexpectedly: {ex.Message}", "ERROR");
            }
            catch (Exception ex)
            {
                LogMessage($"Error in client receive loop: {ex.Message}", "ERROR");
            }
        }

        public async void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
            {
                LogMessage("Message cannot be empty.", "ERROR");
                return;
            }

            try
            {
                if (clientWriter != null)
                {
                    await clientWriter.WriteLineAsync(message);
                    LogMessage($"You: {message}");
                    LogMessage("Client sent message.");
                    txtMessage.Clear();
                }
                else if (serverClientWriter != null)
                {
                    await serverClientWriter.WriteLineAsync(message);
                    LogMessage($"You (Server Client): {message}");
                    LogMessage("Server client sent message.");
                    txtMessage.Clear();
                }
                else
                {
                    LogMessage("Connection is not established.", "ERROR");
                }
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
                    LogMessage("You have disconnected from the server.");
                    clientStream?.Close();
                    client.Close();
                }
                if (server != null)
                {
                    LogMessage("Server is shutting down.");
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
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = "netstat";
                    process.StartInfo.Arguments = "-an";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

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
