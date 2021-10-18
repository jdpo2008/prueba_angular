using AP_Examen.Dominio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AP_Examen.Comun.Interfaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        Task<T> GetById(Guid id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllFiltered(Expression<Func<T, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountAllFiltered(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetPagedReponse(int pageNumber, int pageSize);
    }
}
