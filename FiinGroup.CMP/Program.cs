using FiinGroup.CMP.PM.BLImplementations;
using FiinGroup.CMP.PM.BLInterfaces;
using FiinGroup.Packages.Common.Extensions;
using FiinGroup.Packages.Common.MultiLanguage;
using FiinX.Localizer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var service = builder.Services;

service.AddScoped<ICMPService, CMPService>();
service.AddMultiLanguageOptions();
service.AddLocalizer();
service.AddResponseCompression(options => { options.EnableForHttps = true; });
service.AddHttpContextAccessor();
service
     .AddControllers()
     .AddNewtonsoftJson(options =>
     {
         options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
         options.SerializerSettings.Converters.Add(new StringEnumConverter());
     })
     .AddValidationBehavior()
     .AddApiVersioning();

var app = builder.Build();
app.UseLocalizer();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMultiLanguage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
