using AP_Examen.Comun.Interfaces;
using AP_Examen.Comun.Interfaces.Repositorios;
using AP_Examen.Persistencia.Contexts;
using AP_Examen.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Persistencia
{
    public static class ServiceRegistration
    {
        public static void AddPersistenciaServices(this IServiceCollection services, IConfiguration configuration)
        {

            string ConnectionString = configuration.GetConnectionString("DefaultConnection");

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ExamenContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ExamenContext>(options =>
               options.UseSqlServer(
                   ConnectionString,
                   b => b.MigrationsAssembly("AP_Examen.Persistencia"))
               );
            }

            #region Repositories
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddTransient<IAlumnoRepositorio, AlumnoRepositorio>();
            services.AddTransient<ICursoRepositorio, CursoRepositorio>();
            services.AddTransient<INotasAlumnosRepositorio, NotasAlumnosRepositorio>();
            #endregion

        }
    }
}
