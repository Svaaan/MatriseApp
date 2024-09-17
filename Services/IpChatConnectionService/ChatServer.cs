using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Matrise.Services.Chat
{
    public class ChatServer
    {
        private TcpListener server;
        private readonly ConcurrentDictionary<TcpClient, NetworkStream> connectedClients = new(); // Thread-safe collection for clients

        public event Action<string> MessageReceived;

        public async Task StartServerAsync(int port)
        {
            if (server != null)
            {
                server.Stop(); // Stop any existing server instance
            }

            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine($"Server started on port {port}.");

            // Continuously accept clients
            while (true)
            {
                try
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    NetworkStream clientStream = client.GetStream();

                    // Add the new client to the list of connected clients
                    connectedClients.TryAdd(client, clientStream);

                    Console.WriteLine("Client connected.");

                    // Notify all clients about the new connection
                    BroadcastMessage("A new client has connected.");

                    // Start receiving messages from the client
                    _ = Task.Run(() => HandleClientAsync(client));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accepting client: {ex.Message}");
                    break;
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream clientStream = client.GetStream();
            using StreamReader reader = new(clientStream);
            try
            {
                while (client.Connected)
                {
                    var message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        Console.WriteLine($"Received: {message}");
                        MessageReceived?.Invoke(message);

                        // Broadcast the message to all connected clients
                        BroadcastMessage(message);
                    }
                    else
                    {
                        // Handle client disconnection
                        Console.WriteLine("Client disconnected.");
                        break;
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Client connection error.");
            }
            finally
            {
                // Cleanup on disconnection
                client.Close();
                connectedClients.TryRemove(client, out _);
                Console.WriteLine("Client removed.");
            }
        }

        private void BroadcastMessage(string message)
        {
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message + Environment.NewLine);

            // Send the message to all connected clients
            foreach (var client in connectedClients.Keys)
            {
                try
                {
                    NetworkStream clientStream = connectedClients[client];
                    clientStream.Write(messageBytes, 0, messageBytes.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error broadcasting to client: {ex.Message}");
                }
            }
        }

        public void StopServer()
        {
            server?.Stop();
            foreach (var client in connectedClients.Keys)
            {
                client.Close();
            }
            connectedClients.Clear();
            Console.WriteLine("Server stopped and all clients disconnected.");
        }
    }
}
