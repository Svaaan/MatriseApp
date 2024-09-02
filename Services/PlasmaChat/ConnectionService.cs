// File: Services/PlasmaChat/ConnectionService.cs
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy.Services.PlasmaChat
{
    public class ConnectionService
    {
        private TcpClient _client;
        private TcpListener _server;
        private StreamReader _clientReader;
        private StreamWriter _clientWriter;
        private TextBox _chatLog;
        private RichTextBox txtChatLog;
        private readonly object _streamLock = new object();

        public StreamWriter ClientWriter => _clientWriter;
        public StreamWriter ServerClientWriter { get; private set; }

        public ConnectionService(TextBox chatLog)
        {
            _chatLog = chatLog;
        }

        public ConnectionService(RichTextBox txtChatLog)
        {
            this.txtChatLog = txtChatLog;
        }

        public async Task StartServerAsync(int port)
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, port);
                _server.Start();
                LogMessage("Server started. Waiting for connection...");
                await Task.Run(ServerListenLoop);
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting server: {ex.Message}", "ERROR");
            }
        }

        public async Task ConnectClientAsync(string ipAddress, int port)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ipAddress, port);
                var clientStream = _client.GetStream();
                _clientWriter = new StreamWriter(clientStream) { AutoFlush = true };
                _clientReader = new StreamReader(clientStream);
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
                    var serverClient = await _server.AcceptTcpClientAsync();
                    var serverClientStream = serverClient.GetStream();
                    ServerClientWriter = new StreamWriter(serverClientStream) { AutoFlush = true };
                    var serverClientReader = new StreamReader(serverClientStream);
                    LogMessage("Client connected successfully.");

                    _ = Task.Run(async () =>
                    {
                        string message;
                        while ((message = await serverClientReader.ReadLineAsync()) != null)
                        {
                            LogMessage($"Client: {message}");
                            await ServerClientWriter.WriteLineAsync($"Server received: {message}");
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
                while ((message = await _clientReader.ReadLineAsync()) != null)
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

        private void LogMessage(string message, string level = "INFO")
        {
            if (_chatLog.InvokeRequired)
            {
                _chatLog.Invoke(new Action(() => LogMessage(message, level)));
                return;
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _chatLog.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        public void Disconnect()
        {
            _client?.Close();
            _server?.Stop();
        }
    }
}
