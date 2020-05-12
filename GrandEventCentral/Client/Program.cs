using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.FileReader;
using GrandEventCentral.Client.Helpers;
using GrandEventCentral.Client.Repository;
using GrandEventCentral.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GrandEventCentral.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<WeatherForecastService>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IDisplayMessage, DisplayMessage>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddTransient<CustomHttpClientFactory>();

            services.AddTelerikBlazor();

            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            services.AddApiAuthorization();
        }
    }
}
