using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Example.Api.Client.CSharp;
using Example.Api.Client.CSharp.Contracts;

namespace TimeKeeper.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");            

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44331/") });

            builder.Services.AddScoped<ITimeEntryClient, TimeEntryClient>(_=>new TimeEntryClient("", new HttpClient { BaseAddress = new Uri("https://localhost:5001/") } ));
            
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
