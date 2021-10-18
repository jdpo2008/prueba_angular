using AP_Examen.Dominio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AP_Examen.Dominio.Entidades
{
    public class NotasAlumno : EntidadBase
    {
        public Guid AlumnoId { get; set; }
        public Guid CursoId { get; set; }

        public decimal Practicas { get; set; }
        public decimal Parcial { get; set; }
        public decimal Final { get; set; }

        public decimal PromedioPracticas { get; set; }
        public decimal PromedioParcial { get; set; }
        public decimal PromedioFinal { get; set; }

        [JsonIgnore]
        public virtual Curso Curso { get; set; }
        [JsonIgnore]
        public virtual Alumno Alumno { get; set; }

    }
}
