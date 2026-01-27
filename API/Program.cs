using FiinGroup.CMP.API.BLImplementations;
using FiinGroup.CMP.API.BLInterfaces;
using FiinGroup.Packages.CacheManager;
using StoxPlus.Infrastructure.Behaviors;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
// Register application services
builder.Services.AddScoped<ICMPService, CMPService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMediator(options => { options.AddCacheBehavior<MediatorCacheHandler>(); });
services.AddCacheManager(options => { options.UseMemoryCache(ExpirationMode.Absolute, TimeSpan.FromMinutes(30)); });
services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
