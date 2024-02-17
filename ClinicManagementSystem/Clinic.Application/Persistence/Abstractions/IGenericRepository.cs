using System.Linq.Expressions;

namespace ClinicManagement.Application.Persistence.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T? GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Get(Expression<Func<T, bool>> filter);
        T Create(T entity);
        T Update(T entity);
        T? DeleteById(int id);
        IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
    }
}
