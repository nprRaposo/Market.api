using Market.Api.Domain.Repositories;
using Market.Api.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Market.Api.Persistence.Repositories
{
    public class Repository <T>: IRepository<T> where T: class
    {
        internal DbSet<T> _dbSet;
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            this._dbSet = context.Set<T>();
            this._context = context;
        }

        public virtual async Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IEnumerable<string> includeProperties = null)
        {
            IQueryable<T> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            this._dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        private void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this._dbSet.Attach(entityToDelete);
            }

            this._dbSet.Remove(entityToDelete);
        }
    }
}
