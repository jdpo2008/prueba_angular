using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Dominio.Comun
{
    public abstract class EntidadBase : EntidadBaseAuditable
    {
        public virtual Guid Id { get; set; }
    }
}
