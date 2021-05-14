using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using TimeKeeper.Repository;

namespace TimeKeeper.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            TimeKeeperContext timeKeeperContext = new(Configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<ICategoryRepository>(_ => new CategoryRepository(timeKeeperContext));
            services.AddScoped<IClientRepository>(_ => new ClientRepository(timeKeeperContext));
            services.AddScoped<IRegionalOfficeRepository>(_ => new RegionalOfficeRepository(timeKeeperContext));
            services.AddScoped<ITimeEntryRepository>(_ => new TimeEntryRepository(timeKeeperContext, connectionString));
            services.AddScoped<IUserRepository>(_ => new UserRepository(timeKeeperContext));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeKeeper.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeKeeper.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy.WithOrigins("http://localhost:44360", "https://localhost:44360")
            .AllowAnyMethod()
            .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
            .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
