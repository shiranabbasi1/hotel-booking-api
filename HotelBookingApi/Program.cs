using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connectionString, x => x.EnableRetryOnFailure()), ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
