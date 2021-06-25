using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Refit;
using TimeKeeper.Shared.Api;

namespace TimeKeeper.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var apiLocation = builder.Configuration.GetValue<string>("apiLocation") ?? "https://localhost:44331/";

            builder.Services.AddRefitClient<ITimeEntryApi>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(apiLocation); });

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}