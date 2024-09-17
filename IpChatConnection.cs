using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrise
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

        // This method handles both starting a server or connecting to an existing one
        private async void btnStartConnect_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                await ConnectToServerAsync(); // Connecting to a server
            }
            else
            {
                await StartServerAsync(); // Starting the server
            }
        }

        // Method to start the server
        private async Task StartServerAsync()
        {
            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                MessageBox.Show("Invalid port number.");
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

                isServerRunning = true;
                btnStartConnect.Text = "Connect";

                // Wait for a client to connect in a background task
                serverClient = await server.AcceptTcpClientAsync();
                serverClientStream = serverClient.GetStream();

                // Open the Chat form and pass the server's client stream
                Invoke(new Action(() =>
                {
                    var chatForm = new Chat(serverClientStream, "ServerNickname", "0.0.0.0", port); // Server IP can be "0.0.0.0"
                    chatForm.Show();
                    this.Hide(); // Optionally hide the current form
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server: {ex.Message}");
            }
        }

        // Method to connect as a client
        private async Task ConnectToServerAsync()
        {
            string ipAddress = txtIPAddress.Text;
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Invalid IP address.");
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port >= 65536)
            {
                MessageBox.Show("Invalid port number.");
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ipAddress, port); // Connect to the server
                clientStream = client.GetStream();
                clientWriter = new StreamWriter(clientStream) { AutoFlush = true };
                clientReader = new StreamReader(clientStream);

                // Show the Chat form and hide the connection form
                var chatForm = new Chat(clientStream, "ClientNickname", ipAddress, port);
                chatForm.Show();
                this.Hide();

                // Log connection successful
                Console.WriteLine($"Connection successful: IP = {ipAddress}, Port = {port}");

                // Start receiving messages from the server in a background task
                _ = Task.Run(ClientReceiveLoop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}");
            }
        }

        // Background task for continuously receiving messages
        private async Task ClientReceiveLoop()
        {
            try
            {
                string message;
                while ((message = await clientReader.ReadLineAsync()) != null)
                {
                    // Handle received messages here (e.g., show in chat form)
                    Console.WriteLine($"Received: {message}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error in client receive loop: {ex.Message}");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"Stream closed unexpectedly: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in client receive loop: {ex.Message}");
            }
        }

        // Example method for showing open ports (netstat command)
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

                    // Display the open ports in a multiline TextBox or other control
                    //txtPortLog.Text = output; // Assuming you have a multiline TextBox called txtPortLog
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing netstat: {ex.Message}");
            }
        }
    }
}
