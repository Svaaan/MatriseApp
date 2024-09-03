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
        private bool isServerRunning = false;

        public IpChatConnection()
        {
            InitializeComponent();
        }

        private async void btnStartConnect_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                await ConnectToServerAsync();
            }
            else
            {
                await StartServerAsync();
            }
        }

        private async Task StartServerAsync()
        {
            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                // Error handling without MessageBox
                // Example: Log error, set status label, etc.
                Console.WriteLine("Invalid port number.");
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

                // Update UI to show server started status
                isServerRunning = true;
                btnStartConnect.Text = "Connect";

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
                // Log error
                Console.WriteLine($"Error starting server: {ex.Message}");
            }
        }

        private async Task ConnectToServerAsync()
        {
            string ipAddress = txtIPAddress.Text;
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                // Error handling without MessageBox
                // Example: Log error, set status label, etc.
                Console.WriteLine("Invalid IP address.");
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                // Error handling without MessageBox
                // Example: Log error, set status label, etc.
                Console.WriteLine("Invalid port number.");
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ipAddress, port);
                clientStream = client.GetStream();
                clientWriter = new StreamWriter(clientStream) { AutoFlush = true };
                clientReader = new StreamReader(clientStream);

                // Update UI to show connected status
                var chatForm = new Chat(clientStream, "ClientNickname"); // Provide the nickname
                chatForm.Show();
                this.Hide(); // Optionally hide the current form

                // Start receiving messages from the server
                await Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }
        }

        private async Task ClientReceiveLoop()
        {
            try
            {
                string message;
                while ((message = await clientReader.ReadLineAsync()) != null)
                {
                    // Handle the received message (implementation depends on Chat form)
                }
            }
            catch (IOException ex)
            {
                // Log error
                Console.WriteLine($"I/O error in client receive loop: {ex.Message}");
            }
            catch (ObjectDisposedException ex)
            {
                // Log error
                Console.WriteLine($"Stream closed unexpectedly: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error in client receive loop: {ex.Message}");
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

                    // Display result in a UI control or handle it as needed
                    Console.WriteLine(output); // Example: Log output
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error executing netstat: {ex.Message}");
            }
        }
    }
}
