using AP_Examen.Persistencia.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP_Examen.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var isDevelopment = services.GetRequiredService<IWebHostEnvironment>().IsDevelopment();
                    using var appContext = services.GetRequiredService<ExamenContext>();

                    if (isDevelopment)
                    {
                        await appContext.Database.EnsureCreatedAsync();
                        await Persistencia.Seeds.CursosPorDefault.SeedAsync(appContext);
                    }
                    else
                    {
                        await appContext.Database.MigrateAsync();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
