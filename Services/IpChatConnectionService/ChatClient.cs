using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
//Client side logic
namespace Matrise.Services.Chat
{
    public class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;

        public NetworkStream NetworkStream => stream;  // Expose the NetworkStream

        public event Action<string> MessageReceived;

        public async Task ConnectToServerAsync(string ipAddress, int port)
        {
            client = new TcpClient();
            await client.ConnectAsync(ipAddress, port);
            stream = client.GetStream();

            // Start listening for messages from the server
            _ = Task.Run(ReceiveMessagesAsync);
        }

        private async Task ReceiveMessagesAsync()
        {
            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    try
                    {
                        var message = await reader.ReadLineAsync();
                        if (message != null)
                        {
                            MessageReceived?.Invoke(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error receiving message: {ex.Message}");
                        break;
                    }
                }
            }
        }
    }
}
