using AP_Examen.Comun.DTOs;
using AP_Examen.Comun.Interfaces;
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
    public class AlumnoRepositorio : RepositorioGenerico<Alumno>, IAlumnoRepositorio
    {
        private readonly DbSet<Alumno> _alumnos;

        public AlumnoRepositorio(ExamenContext dbContext) : base(dbContext)
        {
            _alumnos = dbContext.Set<Alumno>();
        }
        public async Task<Alumno> ObtenerAlumnoById(Guid id)
        {
            return await _alumnos.Include(c => c.Cursos).Include(n => n.NotasAlumno).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Alumno>> ObtenerAlumnos()
        {
            return await _alumnos.Include(c => c.Cursos).Include(n => n.NotasAlumno).ToListAsync();
        }

        public async Task<Alumno> ObtenerAlumnoByDni(string dni)
        {
            return await _alumnos.Include(c => c.Cursos).Include(n => n.NotasAlumno).FirstOrDefaultAsync(p => p.Dni == dni);
        }

        
    }
}
