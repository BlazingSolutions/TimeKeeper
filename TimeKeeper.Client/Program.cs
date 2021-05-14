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

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IRegionalOfficeService, RegionalOfficeService>();
            builder.Services.AddScoped<ITimeEntryService, TimeEntryService>();
            builder.Services.AddScoped<IUserService, UserService>();

            await builder.Build().RunAsync();
        }
    }
}
