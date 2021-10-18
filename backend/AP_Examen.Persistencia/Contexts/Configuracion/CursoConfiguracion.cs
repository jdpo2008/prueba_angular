using AP_Examen.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Persistencia.Contexts.Configuracion
{
    public class CursoConfiguracion : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(25);
            builder.Property(a => a.Descripcion).IsRequired().HasMaxLength(150);
            
        }
    }
}
