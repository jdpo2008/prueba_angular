using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AP_Examen.Dominio.Comun;
using AP_Examen.Dominio.Entidades;
using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AP_Examen.Persistencia.Contexts
{
    public class ExamenContext : DbContext
    {
        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<NotasAlumno> NotasAlumnos { get; set; }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntidadBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        entry.Entity.IdUsuarioCreacion = Guid.NewGuid();
                        entry.CurrentValues["Activo"] = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.FechaEdicion = DateTime.Now;
                        entry.Entity.IdUsuarioEdicion = Guid.NewGuid();
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Activo"] = false;
                        entry.Entity.FechaEdicion = DateTime.Now;
                        entry.Entity.IdUsuarioEdicion = Guid.NewGuid();
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyAllConfigurationsFromCurrentAssembly();

            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }


            builder.Entity<Alumno>().Property<bool>("Activo");
            builder.Entity<Alumno>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

            builder.Entity<Curso>().Property<bool>("Activo");
            builder.Entity<Curso>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

            builder.Entity<NotasAlumno>().Property<bool>("Activo");
            builder.Entity<NotasAlumno>().HasQueryFilter(m => EF.Property<bool>(m, "Activo") == true);

            builder.HasDefaultSchema("dbo");
            builder.Entity<Alumno>().ToTable("AP_Perez_Jose_Alumno", "dbo");
            builder.Entity<Curso>().ToTable("AP_Perez_Jose_Curso", "dbo");
            builder.Entity<NotasAlumno>().ToTable("AP_Perez_Jose_NotasAlumno", "dbo");
            
        }

    }
}
