// File: Services/PlasmaChat/ChatService.cs
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp00ksy.Services.PlasmaChat
{
    public class ChatService
    {
        private readonly TextBox _chatLog;
        private readonly StreamWriter _clientWriter;
        private readonly StreamWriter _serverClientWriter;
        private RichTextBox txtChatLog;
        private StreamWriter clientWriter;
        private StreamWriter serverClientWriter;

        public ChatService(TextBox chatLog, StreamWriter clientWriter, StreamWriter serverClientWriter)
        {
            _chatLog = chatLog;
            _clientWriter = clientWriter;
            _serverClientWriter = serverClientWriter;
        }

        public ChatService(RichTextBox txtChatLog, StreamWriter clientWriter, StreamWriter serverClientWriter)
        {
            this.txtChatLog = txtChatLog;
            this.clientWriter = clientWriter;
            this.serverClientWriter = serverClientWriter;
        }

        public void LogMessage(string message, string level = "INFO")
        {
            if (_chatLog.InvokeRequired)
            {
                _chatLog.Invoke(new Action(() => LogMessage(message, level)));
                return;
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _chatLog.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        public async Task SendMessageAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                LogMessage("Message cannot be empty.", "ERROR");
                return;
            }

            try
            {
                if (_clientWriter != null)
                {
                    await _clientWriter.WriteLineAsync(message);
                    LogMessage($"You: {message}");
                }
                else if (_serverClientWriter != null)
                {
                    await _serverClientWriter.WriteLineAsync(message);
                    LogMessage($"You (Server Client): {message}");
                }
                else
                {
                    LogMessage("Connection is not established.", "ERROR");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending message: {ex.Message}", "ERROR");
            }
        }
    }
}
