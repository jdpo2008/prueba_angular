using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Dominio.Comun
{

    public abstract class EntidadBaseAuditable
    {
        public Guid IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? IdUsuarioEdicion { get; set; }
        public DateTime? FechaEdicion { get; set; }
    }
    
}
