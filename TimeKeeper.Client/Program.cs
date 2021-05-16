using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Threading.Tasks;
using Refit;
using TimeKeeper.ComponentLibrary.Api;

namespace TimeKeeper.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddRefitClient<ITimeEntryApi>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://localhost:5001/"); });

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}