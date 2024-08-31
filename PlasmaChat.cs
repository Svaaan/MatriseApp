using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Sp00ksy
{
    public partial class PlasmaChat : Form
    {
        private RSAParameters privateKey;
        private RSAParameters publicKey;
        private RSAParameters partnerPublicKey;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream stream;

        public PlasmaChat()
        {
            InitializeComponent();
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

        // Button Click to Start Server
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            ThreadPool.QueueUserWorkItem(ServerListenLoop);
            LogMessage("Server started. Waiting for connection...");
        }

        // Button Click to Connect to Server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text;
            int port = int.Parse(txtPort.Text);
            client = new TcpClient(ipAddress, port);
            stream = client.GetStream();
            ThreadPool.QueueUserWorkItem(ClientReceiveLoop);
            SendPublicKey();
            LogMessage("Connected to server.");
        }

        private void SendPublicKey()
        {
            var publicKeyBytes = ConvertPublicKeyToBytes(publicKey);
            stream.Write(publicKeyBytes, 0, publicKeyBytes.Length);
        }

        private void ServerListenLoop(object state)
        {
            while (true)
            {
                using (var client = server.AcceptTcpClient())
                {
                    stream = client.GetStream();
                    partnerPublicKey = ReceivePublicKey();

                    // Keep listening for messages from the client
                    using (var sr = new StreamReader(stream))
                    {
                        while (true)
                        {
                            var encryptedMessage = sr.ReadLine();
                            if (encryptedMessage == null) break;
                            var decryptedMessage = DecryptMessage(Convert.FromBase64String(encryptedMessage));
                            LogMessage($"Client: {decryptedMessage}");
                        }
                    }
                }
            }
        }

        private void ClientReceiveLoop(object state)
        {
            partnerPublicKey = ReceivePublicKey();

            using (var sr = new StreamReader(stream))
            {
                while (true)
                {
                    var encryptedMessage = sr.ReadLine();
                    if (encryptedMessage == null) break;
                    var decryptedMessage = DecryptMessage(Convert.FromBase64String(encryptedMessage));
                    LogMessage($"Server: {decryptedMessage}");
                }
            }
        }

        private RSAParameters ReceivePublicKey()
        {
            var publicKeyBytes = new byte[2048];
            int bytesRead = stream.Read(publicKeyBytes, 0, publicKeyBytes.Length);
            return ConvertBytesToPublicKey(publicKeyBytes, bytesRead);
        }

        // Button Click to Send Message
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            var encryptedMessage = EncryptMessage(message, partnerPublicKey);
            var sw = new StreamWriter(stream) { AutoFlush = true };
            sw.WriteLine(Convert.ToBase64String(encryptedMessage));
            LogMessage($"You: {message}");
            txtMessage.Clear();
        }

        private byte[] EncryptMessage(string message, RSAParameters publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(Encoding.UTF8.GetBytes(message), false);
            }
        }

        private string DecryptMessage(byte[] encryptedMessage)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                var decryptedBytes = rsa.Decrypt(encryptedMessage, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        private byte[] ConvertPublicKeyToBytes(RSAParameters publicKey)
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

        private RSAParameters ConvertBytesToPublicKey(byte[] bytes, int length)
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

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogMessage(message)));
                return;
            }
            txtChatLog.AppendText($"{message}{Environment.NewLine}");
        }
    }
}
