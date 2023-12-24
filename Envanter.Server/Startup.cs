using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Envanter.Server.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Envanter.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLocalization(options => options.ResourcesPath = "Shared.Resources");
            //services.AddScoped<MahkemeDosyasiService>();
            var connectionString = Configuration.GetConnectionString("SQLDbConnection");
            services.AddDbContext<EnvanterDbContext>(options => options.UseSqlServer(connectionString));

            /* MYSQL kullanırsak connector için .Net 8.0 uyumlu Pomelo.EntityFrameworkCore.MySql yüklemelisin ve değişkenler aşağıdaki gibi olmalı
             var connectionString = Configuration.GetConnectionString("MYSQLDbConnection");
             services.AddDbContext<RaporDataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            */

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 32;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("tr-TR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            // Diğer middleware'ler
        }

    }
}
