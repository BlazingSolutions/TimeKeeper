using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeKeeper.Services;

namespace TimeKeeper.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");            

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44331/") });
            builder.Services.AddMudServices();

            builder.Services.AddScoped<ITimeEntryService, TimeEntryService>();

            await builder.Build().RunAsync();
        }
    }
}
