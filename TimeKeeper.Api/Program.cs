using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using TimeKeeper.Api.Data;
using TimeKeeper.Api.Infrastructure;
using TimeKeeper.Shared.Api.Features.TimeEntry;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TimeKeeperContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped(_ => new SqlConnection(connectionString));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers(options => { options.Filters.Add<ValidatorActionFilter>(); })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTimeEntry.CommandValidator>());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "TimeKeeper.Api", Version = "v1"});
});

await using var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeKeeper.Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors(policy => policy.WithOrigins("http://localhost:44360", "https://localhost:44360", "http://localhost:5002",
        "https://localhost:5003")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
    .AllowCredentials());

app.Run();