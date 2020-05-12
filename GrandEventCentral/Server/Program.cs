using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GrandEventCentral.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json",
    optional: true,
    reloadOnChange: true);
})
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
    webBuilder.UseStaticWebAssets();
});
        }
    }
}
