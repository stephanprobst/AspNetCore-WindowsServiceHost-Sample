using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsServiceHost
{
    public class CustomServiceHost : WebHostService
    {
        private ILogger<CustomServiceHost> _logger;

        public CustomServiceHost(IWebHost host) : base(host)
        {
            _logger = host.Services.GetRequiredService<ILogger<CustomServiceHost>>();
        }

        protected override void OnStarting(string[] args)
        {
            _logger.LogDebug("OnStarting method called.");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            _logger.LogDebug("OnStarted method called.");
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            _logger.LogDebug("OnStopping method called.");
            base.OnStopping();
        }
    }
}
