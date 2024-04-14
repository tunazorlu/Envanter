using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Envanter.Server.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Envanter.Server
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; }

        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<MahkemeDosyasiService>();
            var connectionString = Configuration.GetConnectionString("SQLDbConnection");
            services.AddDbContext<EnvanterDbContext>(options => options.UseSqlServer(connectionString));

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
