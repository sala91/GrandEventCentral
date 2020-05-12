using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GrandEventCentral.Server.Areas.Identity.IdentityHostingStartup))]
namespace GrandEventCentral.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}