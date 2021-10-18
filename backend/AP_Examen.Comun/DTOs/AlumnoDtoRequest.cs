using AP_Examen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Comun.DTOs
{
    public class AlumnoDtoRequest
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public ICollection<Curso> Cursos { get; set; }
        public ICollection<NotasAlumno> NotasAlumno { get; set; }
    }
}
