using System.Net; // DNS için
using System.Net.Sockets; // AddressFamily

namespace BlogProject.Infrastructure.Utilities
{
    public static class RemoteIpAddress
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return "Ip address not found.";
        }

        public static string IpAddress => GetIpAddress();
    }
}
