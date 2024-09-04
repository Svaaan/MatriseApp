using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
//Server Side Logic
namespace Sp00ksy.Services.Chat
{
    public class ChatServer
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream clientStream;

        public event Action<NetworkStream, string, string, int> ClientConnected;

        public async Task StartServerAsync(int port)
        {
            if (server != null)
            {
                server.Stop(); // Stop any existing server instance
            }

            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            client = await server.AcceptTcpClientAsync();
            clientStream = client.GetStream();

            // Raise an event to notify that a client has connected
            ClientConnected?.Invoke(clientStream, "ServerNickname", "0.0.0.0", port);
        }

        public void StopServer()
        {
            server?.Stop();
        }
    }
}
