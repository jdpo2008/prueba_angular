using AP_Examen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Comun.Interfaces.Repositorios
{
    public interface INotasAlumnosRepositorio : IRepositorioGenerico<NotasAlumno>
    {
        Task<IEnumerable<NotasAlumno>> ObtenerNotasAlumnos(Guid alumnoId);
    }
}
