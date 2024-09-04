using System.Net.NetworkInformation;

namespace Matrise.Services.PingCheck
{
    public class PingResult
    {
        public string Address { get; set; }
        public long RoundtripTime { get; set; }
        public int Ttl { get; set; }
        public int BufferSize { get; set; }
        public IPStatus Status { get; set; }
        public bool IsSuccess { get; set; }
        public string AddressType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
