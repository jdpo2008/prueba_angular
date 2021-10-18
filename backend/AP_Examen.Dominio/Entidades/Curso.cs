using AP_Examen.Dominio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP_Examen.Dominio.Entidades
{
    public class Curso : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Obligatoriedad { get; set; }
        [JsonIgnore]
        public virtual ICollection<Alumno> Alumnos { get; set; }
        [JsonIgnore]
        public virtual ICollection<NotasAlumno> NotasAlumnos { get; set; }
    }
}
