using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sp00ksy.Services.Helpers; // Ensure this namespace is included to access MatrixRain

namespace Sp00ksy
{
    public partial class PlasmaChat : Form
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
        private System.Windows.Forms.Timer transitionTimer; // Explicitly use System.Windows.Forms.Timer
        private MatrixRain matrixRain;

        public PlasmaChat()
        {
            InitializeComponent();
            InitializeTransitionTimer();
        }

        private void InitializeTransitionTimer()
        {
            transitionTimer = new System.Windows.Forms.Timer // Explicitly use System.Windows.Forms.Timer
            {
                Interval = 2000 // Duration for the Matrix Rain effect
            };
            transitionTimer.Tick += TransitionTimer_Tick;
        }

        private void StartTransition()
        {
            if (matrixRain == null)
            {
                matrixRain = new MatrixRain
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };
                this.Controls.Add(matrixRain);
                this.Controls.SetChildIndex(matrixRain, 0); // Ensure it's behind other controls
            }
            transitionTimer.Start();
        }

        private void TransitionTimer_Tick(object sender, EventArgs e)
        {
            transitionTimer.Stop();
            if (matrixRain != null)
            {
                this.Controls.Remove(matrixRain);
                matrixRain.Dispose();
                matrixRain = null;
            }
        }

        private void ClearLogs()
        {
            txtChatLog.Clear();
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            // Start Matrix Rain transition
            StartTransition();

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
            // Start Matrix Rain transition
            StartTransition();

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
                    await clientWriter.WriteLineAsync(message);
                    LogMessage($"You: {message}"); // Keep this log to show the message was sent
                    txtMessage.Clear();
                }
                else if (serverClientWriter != null)
                {
                    await serverClientWriter.WriteLineAsync(message);
                    LogMessage($"You (Server Client): {message}"); // Keep this log to show the message was sent
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

        private void SaveLogsToFile()
        {
            try
            {
                // Set the file path and name
                string fileName = $"ChatLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                // Write the log content to the file
                File.WriteAllText(filePath, txtChatLog.Text);

                // Inform the user
                MessageBox.Show($"Chat log saved to {filePath}", "Log Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving log: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveLogs_Click(object sender, EventArgs e)
        {
            SaveLogsToFile();
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            ClearLogs();
        }
    }
}
