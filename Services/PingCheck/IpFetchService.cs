using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Matrise.Services.PingCheck
{
    public class IpFetchService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetPublicIpAddressAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://api.ipify.org?format=text");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching IP address: {ex.Message}");
            }
        }
    }
}
