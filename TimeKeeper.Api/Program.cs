using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using TimeKeeper.Api.Data;
using TimeKeeper.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TimeKeeperContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped(_ => new SqlConnection(connectionString));

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddCors();

var app = builder.Build();
app.MapCarter();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(policy => policy.WithOrigins("http://localhost:44360", "https://localhost:44360",
        "http://localhost:5002", "https://localhost:5003")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
    .AllowCredentials());

app.UseAuthorization();

app.Run();