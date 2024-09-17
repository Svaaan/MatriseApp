using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Matrise.Services.Chat
{
    public class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;

        public NetworkStream NetworkStream => stream;  // Expose the NetworkStream

        public event Action<string> MessageReceived;
        public event Action Disconnected;  // Event for handling disconnections

        public async Task ConnectToServerAsync(string ipAddress, int port)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ipAddress, port);
                stream = client.GetStream();
                reader = new StreamReader(stream);

                // Start listening for messages from the server
                _ = Task.Run(ReceiveMessagesAsync);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            try
            {
                while (client.Connected)
                {
                    var message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        MessageReceived?.Invoke(message);  // Raise event for received message
                    }
                    else
                    {
                        // If null, the connection is likely closed
                        Console.WriteLine("Server closed the connection.");
                        Disconnect();
                        break;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error receiving message: {ex.Message}");
                Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                Disconnect();
            }
        }

        public void Disconnect()
        {
            if (client != null && client.Connected)
            {
                client.Close();
                reader?.Dispose();
                stream?.Dispose();

                Disconnected?.Invoke();  // Trigger disconnected event
                Console.WriteLine("Disconnected from server.");
            }
        }
    }
}
