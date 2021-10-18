using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Comun.DTOs
{
    public class CursoDtoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Obligatoriedad { get; set; }
    }
}
