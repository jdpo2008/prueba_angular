using AP_Examen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Comun.Interfaces.Repositorios
{
    public interface IAlumnoRepositorio : IRepositorioGenerico<Alumno>
    {
        Task<Alumno> ObtenerAlumnoById(Guid id);
        Task<IEnumerable<Alumno>> ObtenerAlumnos();
        Task<Alumno> ObtenerAlumnoByDni(string dni);
    }
}
