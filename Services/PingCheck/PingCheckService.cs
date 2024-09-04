using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Sp00ksy.Services.PingCheck
{
    public class PingService
    {
        public async Task<PingResult> PingAsync(string ipAddress)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(ipAddress);

                    if (reply.Status == IPStatus.Success)
                    {
                        return new PingResult
                        {
                            Address = reply.Address.ToString(),
                            RoundtripTime = reply.RoundtripTime,
                            Ttl = reply.Options.Ttl,
                            BufferSize = reply.Buffer.Length,
                            Status = reply.Status,
                            IsSuccess = true,
                            AddressType = reply.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? "IPv4" : "IPv6"
                        };
                    }
                    else
                    {
                        return new PingResult
                        {
                            Status = reply.Status,
                            IsSuccess = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new PingResult
                {
                    ErrorMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
