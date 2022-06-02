using HotelBookingApi.Config.AutoMapper;
using HotelBookingApi.Config.File;
using HotelBookingApi.Config.Seed;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories.Implementations;
using HotelBookingApi.Repositories.Interfaces;
using HotelBookingApi.Services.Implementations;
using HotelBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddControllers();

builder.Services.Configure<FileSettings>(builder.Configuration.GetSection(nameof(FileSettings)));
builder.Services.AddSingleton<FileSettings>(x => x.GetRequiredService<IOptions<FileSettings>>().Value);

builder.Services.Configure<SeedSettings>(builder.Configuration.GetSection(nameof(SeedSettings)));
builder.Services.AddSingleton<SeedSettings>(x => x.GetRequiredService<IOptions<SeedSettings>>().Value);

builder.Services.AddSingleton<IGenericRepository, GenericRepository>();

builder.Services.AddSingleton<IFileServiceResolver, FileServiceResolver>();
builder.Services.AddSingleton<IHotelService, HotelService>();

builder.Services.AddDbContext<ApplicationContext>(o => o.UseLazyLoadingProxies().UseSqlServer(connectionString, x => x.EnableRetryOnFailure()), ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
