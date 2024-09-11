using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Matrise.Services.Chat
{
    public static class NetstatUtility
    {
        public static async Task<string> GetOpenPortsAsync()
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "netstat";
                    process.StartInfo.Arguments = "-an";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string output = await process.StandardOutput.ReadToEndAsync();
                    process.WaitForExit();

                    return output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing netstat: {ex.Message}");
                return null;
            }
        }
    }
}
