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
        private RSAEncryption rsaEncryption;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream stream;
        private readonly object streamLock = new object();

        public PlasmaChat()
        {
            InitializeComponent();
            rsaEncryption = new RSAEncryption();
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
                var publicKeyBytes = rsaEncryption.ConvertPublicKeyToBytes();
                lock (streamLock)
                {
                    stream.Write(publicKeyBytes, 0, publicKeyBytes.Length);
                }
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
                        rsaEncryption.PartnerPublicKey = await ReceivePublicKeyAsync(stream);
                        LogMessage("Client connected.");

                        using (var sr = new StreamReader(stream))
                        {
                            string encryptedMessage;
                            while ((encryptedMessage = await sr.ReadLineAsync()) != null)
                            {
                                var decryptedMessage = rsaEncryption.DecryptMessage(Convert.FromBase64String(encryptedMessage));
                                LogMessage($"Client: {decryptedMessage}");
                            }
                        }
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
                rsaEncryption.PartnerPublicKey = await ReceivePublicKeyAsync(stream);

                using (var sr = new StreamReader(stream))
                {
                    string encryptedMessage;
                    while ((encryptedMessage = await sr.ReadLineAsync()) != null)
                    {
                        var decryptedMessage = rsaEncryption.DecryptMessage(Convert.FromBase64String(encryptedMessage));
                        LogMessage($"Server: {decryptedMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error in client receive loop: {ex.Message}", "ERROR");
            }
        }

        private async Task<RSAParameters> ReceivePublicKeyAsync(NetworkStream stream)
        {
            try
            {
                var publicKeyBytes = new byte[2048];
                int bytesRead = await stream.ReadAsync(publicKeyBytes, 0, publicKeyBytes.Length);
                return rsaEncryption.ConvertBytesToPublicKey(publicKeyBytes, bytesRead);
            }
            catch (Exception ex)
            {
                LogMessage($"Error receiving public key: {ex.Message}", "ERROR");
                return default;
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
                var encryptedMessage = rsaEncryption.EncryptMessage(message);
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
            client?.Close();
            server?.Stop();
        }
    }

    public class RSAEncryption
    {
        private RSAParameters privateKey;
        private RSAParameters publicKey;
        public RSAParameters PartnerPublicKey { get; set; }

        public RSAEncryption()
        {
            GenerateKeys();
        }

        private void GenerateKeys()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                privateKey = rsa.ExportParameters(true);
                publicKey = rsa.ExportParameters(false);
            }
        }

        public byte[] EncryptMessage(string message)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(PartnerPublicKey);
                return rsa.Encrypt(Encoding.UTF8.GetBytes(message), false);
            }
        }

        public string DecryptMessage(byte[] encryptedMessage)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                var decryptedBytes = rsa.Decrypt(encryptedMessage, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        public byte[] ConvertPublicKeyToBytes()
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(ms))
                {
                    writer.Write(publicKey.Modulus.Length);
                    writer.Write(publicKey.Modulus);
                    writer.Write(publicKey.Exponent.Length);
                    writer.Write(publicKey.Exponent);
                }
                return ms.ToArray();
            }
        }

        public RSAParameters ConvertBytesToPublicKey(byte[] bytes, int length)
        {
            using (var ms = new MemoryStream(bytes, 0, length))
            {
                using (var reader = new BinaryReader(ms))
                {
                    var modulusLength = reader.ReadInt32();
                    var modulus = reader.ReadBytes(modulusLength);

                    var exponentLength = reader.ReadInt32();
                    var exponent = reader.ReadBytes(exponentLength);

                    return new RSAParameters { Modulus = modulus, Exponent = exponent };
                }
            }
        }
    }
}
