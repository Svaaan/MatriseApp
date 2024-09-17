using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrise
{
    public partial class Chat : Form
    {
        private NetworkStream stream;
        private StreamWriter writer;
        private string nickname;
        private string ipAddress;
        private int port;

        public Chat(NetworkStream stream, string nickname, string ipAddress, int port)
        {
            InitializeComponent();
            this.stream = stream;
            this.nickname = nickname;
            this.ipAddress = ipAddress;
            this.port = port;
            FormClosing += Chat_FormClosing; // Register the FormClosing event handler

            // Initialize StreamWriter once to avoid multiple instantiations
            writer = new StreamWriter(stream) { AutoFlush = true };

            // Log connection success
            LogMessage($"Connection successful: IP = {ipAddress}, Port = {port}", "INFO");
        }

        public void LogMessage(string message, string level = "INFO")
        {
            if (InvokeRequired)
            {
                // Use BeginInvoke for non-blocking UI thread updates
                BeginInvoke(new Action(() => LogMessage(message, level)));
                return;
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtChatLog.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
            {
                LogMessage("Message cannot be empty.", "ERROR");
                return;
            }

            try
            {
                // Send the message asynchronously to avoid blocking the UI
                await writer.WriteLineAsync($"{nickname}: {message}");

                LogMessage($"You: {message}"); // Log the sent message
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending message: {ex.Message}", "ERROR");
            }
        }

        private void btnSaveLogs_Click(object sender, EventArgs e)
        {
            SaveLogsToFile();
        }

        private void SaveLogsToFile()
        {
            try
            {
                string fileName = $"ChatLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

                File.WriteAllText(filePath, txtChatLog.Text);
                LogMessage($"Chat log saved at {filePath}", "INFO");
            }
            catch (Exception ex)
            {
                LogMessage($"Error saving log: {ex.Message}", "ERROR");
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            ClearLogs();
        }

        private void ClearLogs()
        {
            txtChatLog.Clear();
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Proper cleanup of NetworkStream and StreamWriter
                writer?.Dispose();
                stream?.Dispose();
            }
            catch (Exception ex)
            {
                LogMessage($"Error closing stream: {ex.Message}", "ERROR");
            }
        }
    }
}
