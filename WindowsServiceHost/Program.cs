using System.IO;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isService = true;
            if (Debugger.IsAttached || args.Contains("--console"))
            {
                isService = false;
            }

            var pathToContentRoot = Directory.GetCurrentDirectory();
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var host = CreateDefaultWebHost(args).UseContentRoot(pathToContentRoot)
                                                 .Build();

            if (isService)
            {
                //host.RunAsService();
                host.RunAsCustomService();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateDefaultWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .UseKestrel(options => options.Listen(IPAddress.Loopback, options.ApplicationServices.GetRequiredService<IConfiguration>().GetValue<int>("Port")))
                          .UseStartup<Startup>();
        }
    }
}
