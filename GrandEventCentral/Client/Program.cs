using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.FileReader;
using GrandEventCentral.Client.Helpers;
using GrandEventCentral.Client.Repository;
using GrandEventCentral.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

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

            var host = builder.Build();

            host.Services
              .UseBootstrapProviders()
              .UseFontAwesomeIcons();

            await host.RunAsync();
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

            services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();
        }
    }
}
