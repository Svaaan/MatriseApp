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

        public IpChatConnection()
        {
            InitializeComponent();
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (server != null)
                {
                    server.Stop(); // Ensure any existing server is stopped before starting a new one
                }

                server = new TcpListener(IPAddress.Any, port);
                server.Start(); // Start listening for incoming connections
                MessageBox.Show($"Server started on port {port}. Waiting for connection...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Start a task to listen for connections
                await Task.Run(async () =>
                {
                    serverClient = await server.AcceptTcpClientAsync();
                    serverClientStream = serverClient.GetStream();

                    // Open the Chat form and pass the server's client stream
                    Invoke(new Action(() => {
                        var chatForm = new Chat(serverClientStream, "ServerNickname"); // Provide the nickname
                        chatForm.Show();
                        this.Hide(); // Optionally hide the current form
                    }));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text;
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Invalid IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ipAddress, port);
                clientStream = client.GetStream();
                clientWriter = new StreamWriter(clientStream) { AutoFlush = true };
                clientReader = new StreamReader(clientStream);
                MessageBox.Show($"Connected to server at {ipAddress}:{port}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the Chat form and pass the client stream
                var chatForm = new Chat(clientStream, "ClientNickname"); // Provide the nickname
                chatForm.Show();
                this.Hide(); // Optionally hide the current form

                // Start receiving messages from the server
                await Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ClientReceiveLoop()
        {
            try
            {
                string message;
                while ((message = await clientReader.ReadLineAsync()) != null)
                {
                    // Display the received message (implementation depends on Chat form)
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"I/O error in client receive loop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show($"Stream closed unexpectedly: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in client receive loop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error executing netstat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
