using Envanter.Server;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// ConfigurationBuilder oluþturuyor ve appsettings.json dosyasý ile bazý giriþ bilgilerini yüklüyorum.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Startup sýnýfýný kullanarak konfigürasyonlarý düzenliyorum.
var startup = new Startup(configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
