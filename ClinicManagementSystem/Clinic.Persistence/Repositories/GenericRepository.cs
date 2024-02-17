using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManagement.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        public EntitiesContext _dbContext;
        DbSet<T> dbSet;
        public GenericRepository(EntitiesContext context)
        {
            _dbContext = context;
            dbSet = _dbContext.Set<T>();
        }

        public T Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            return dbSet.Add(entity).Entity;
        }

        public T? DeleteById(int id)
        {
            T? selected =  dbSet.Find(id);
            if (selected != null)
            {
                dbSet.Remove(selected);
            }
            return selected;
        }

        public  IQueryable<T> GetAll()
         =>  dbSet;

        //public async Task<T?> GetByIdAsync(int id)
        //=> await dbSet.FindAsync(id);

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }
        public T? GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query,
                 (current, include) => current.Include(include));
            }

            return query.Where(i => i.Id == id).FirstOrDefault();
        }


        public IQueryable<T> GetAllIncluding(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if(includeProperties.Length > 0)
            {
                query = includeProperties.Aggregate(query,
                 (current, include) => current.Include(include));
                //foreach (var includeProperty in includeProperties)
                //{
                //    query = query.Include(includeProperty);
                //}
            }

           if(filter != null)
            return query.Where(filter);
           else
                return query;
        }

        public T Update(T entity)
        {
           
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.ModifiedDate = DateTime.Now;
            return dbSet.Update(entity).Entity;
        }

    }
}