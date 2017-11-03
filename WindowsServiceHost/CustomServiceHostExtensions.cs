using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace WindowsServiceHost
{
    public static class CustomServiceHostExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            var serviceHost = new CustomServiceHost(host);
            ServiceBase.Run(serviceHost);
        }
    }
}
