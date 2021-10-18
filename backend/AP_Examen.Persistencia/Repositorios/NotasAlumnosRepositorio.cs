using AP_Examen.Comun.Interfaces.Repositorios;
using AP_Examen.Dominio.Entidades;
using AP_Examen.Persistencia.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Persistencia.Repositorios
{
    public class NotasAlumnosRepositorio :  RepositorioGenerico<NotasAlumno>, INotasAlumnosRepositorio
    {
        private readonly DbSet<NotasAlumno> _notas;

        public NotasAlumnosRepositorio(ExamenContext dbContext) : base(dbContext)
        {
            _notas = dbContext.Set<NotasAlumno>();
        }

        public async Task<IEnumerable<NotasAlumno>> ObtenerNotasAlumnos(Guid alumnoId)
        {
            return await _notas.ToListAsync(); 
        }
    }
}
