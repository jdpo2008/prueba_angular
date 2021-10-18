using AP_Examen.Comun.Interfaces.Repositorios;
using AP_Examen.Dominio.Entidades;
using AP_Examen.Persistencia.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Persistencia.Repositorios
{
    public class CursoRepositorio : RepositorioGenerico<Curso>, ICursoRepositorio
    {
        private readonly DbSet<Curso> _curso;

        public CursoRepositorio(ExamenContext dbContext) : base(dbContext)
        {
            _curso = dbContext.Set<Curso>();
        }

    }
}
