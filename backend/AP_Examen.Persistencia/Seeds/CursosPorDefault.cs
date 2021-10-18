using AP_Examen.Dominio.Entidades;
using AP_Examen.Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Persistencia.Seeds
{
    public static class CursosPorDefault
    {
        public static async Task SeedAsync(ExamenContext context)
        {
            //Seed Roles
            var studentList = new List<Curso>() {
                new Curso(){ Nombre = "Matematicas", Descripcion = "Curso de matematicas", Obligatoriedad = false },
                new Curso(){ Nombre = "Ingles", Descripcion = "Curso de Ingles", Obligatoriedad = false },
                new Curso(){ Nombre = "Algebra", Descripcion = "Curso de Algebra", Obligatoriedad = false },
                new Curso(){ Nombre = "Biologia", Descripcion = "Curso de Biologia", Obligatoriedad = false },
                new Curso(){ Nombre = "Sociales", Descripcion = "Curso de Sociales", Obligatoriedad = false },
            };

            foreach (var item in studentList)
            {

                var existe = context.Cursos.Where(x => x.Nombre == item.Nombre).Count();

                if(existe == 0)
                {
                    await context.AddAsync(item);
                    await context.SaveChangesAsync();
                }

            }
            
        }
    }
}
