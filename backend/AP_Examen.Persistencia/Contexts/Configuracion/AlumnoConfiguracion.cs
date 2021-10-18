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
    public class AlumnoConfiguracion : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
           
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nombres).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Apellidos).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(25);
            builder.Property(a => a.Dni).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Sexo).HasMaxLength(10);
            builder.Property(a => a.Edad).HasColumnType("int");

            builder.HasMany(p => p.Cursos).WithMany(p => p.Alumnos).UsingEntity(j => j.ToTable("AP_Perez_Jose_CursosAlumno"));
        }
    }
}
