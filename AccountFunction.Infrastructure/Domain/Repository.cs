using AccountFunction.Core.Interfaces;
using AccountFunction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Domain
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dataContext.Set<T>().AddRange(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _dataContext.Set<T>().Where(predicate));
        }

        public async Task<T?> Get(long id)
        {
            return  await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _dataContext.Set<T>().Remove(entity);

        }

        public void ReloadEntity<TEntity>(TEntity entity) where TEntity : class
        {
            _dataContext.Entry(entity).Reload();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dataContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dataContext.Set<T>().Attach(entity);
        }
    }
}
