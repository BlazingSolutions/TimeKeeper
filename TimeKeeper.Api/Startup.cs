using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using TimeKeeper.Api.Data;
using TimeKeeper.Api.Infrastructure;
using TimeKeeper.Shared.Api.Features.TimeEntry;

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
            services.AddDbContext<TimeKeeperContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(_ => new SqlConnection(connectionString));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddControllers(options => { options.Filters.Add<ValidatorActionFilter>(); })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Create.CommandValidator>());

            services.ConfigureSwagger();
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

            app.UseCors(policy => policy.WithOrigins("http://localhost:44360", "https://localhost:44360",
                    "http://localhost:5002", "https://localhost:5003")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}