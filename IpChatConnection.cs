using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy
{
    public partial class IpChatConnection : Form
    {
        private TcpClient client;
        private TcpListener server;
        private NetworkStream clientStream;
        private StreamWriter clientWriter;
        private StreamReader clientReader;
        private TcpClient serverClient;
        private NetworkStream serverClientStream;
        private StreamWriter serverClientWriter;
        private readonly object streamLock = new object();
        private string nickname = "Guest"; // Default nickname

        public IpChatConnection()
        {
            InitializeComponent();
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
                if (server != null)
                {
                    server.Stop(); // Ensure any existing server is stopped before starting a new one
                }

                server = new TcpListener(IPAddress.Any, port);
                LogMessage($"Initializing server on port {port}...");
                server.Start(); // Start listening for incoming connections
                LogMessage("Server started. Waiting for connection...");

                // Start a task to listen for connections
                await Task.Run(async () =>
                {
                    serverClient = await server.AcceptTcpClientAsync();
                    serverClientStream = serverClient.GetStream();

                    // Open the Chat form and pass the server's client stream
                    Invoke(new Action(() => {
                        var chatForm = new Chat(serverClientStream);
                        chatForm.Show();
                        this.Hide(); // Optionally hide the current form
                    }));

                    await Task.Run(() => HandleServerClientCommunication());
                });
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
                LogMessage($"Connected to server at {ipAddress}:{port}.");

                // Open the Chat form and pass the client stream
                var chatForm = new Chat(clientStream);
                chatForm.Show();
                this.Hide(); // Optionally hide the current form

                await Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting to server: {ex.Message}", "ERROR");
            }
        }

        private async Task HandleServerClientCommunication()
        {
            // Method to handle communication with connected client
            try
            {
                using (var reader = new StreamReader(serverClientStream))
                using (var writer = new StreamWriter(serverClientStream) { AutoFlush = true })
                {
                    string message;
                    while ((message = await reader.ReadLineAsync()) != null)
                    {
                        LogMessage($"{nickname}: {message}"); // Log received message from client with nickname
                        // Echo message back to client
                        await writer.WriteLineAsync($"{nickname}: {message}");
                    }
                }
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

        private async Task ClientReceiveLoop()
        {
            try
            {
                string message;
                while ((message = await clientReader.ReadLineAsync()) != null)
                {
                    LogMessage(message); // Log received message from server
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

        private async void btnSendMessage_Click(object sender, EventArgs e)
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
                    await clientWriter.WriteLineAsync($"{nickname}: {message}");
                    LogMessage($"You: {message}"); // Log sent message with nickname
                    txtMessage.Clear();
                }
                else if (serverClientWriter != null)
                {
                    await serverClientWriter.WriteLineAsync($"{nickname}: {message}");
                    LogMessage($"You (Server Client): {message}"); // Log sent message with nickname
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

        private void btnUpdateNickname_Click(object sender, EventArgs e)
        {
            string newNickname = txtNickname.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newNickname))
            {
                nickname = newNickname;
                LogMessage($"Nickname updated to: {nickname}");
            }
            else
            {
                LogMessage("Nickname cannot be empty.", "ERROR");
            }
        }
    }
}
