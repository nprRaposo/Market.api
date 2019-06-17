using Market.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Market.Api.Domain.Repositories
{
    public interface IRepository <T> 
    {
        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string[] includeProperties = null);

        Task AddAsync(T entity);

        Task<T> GetById(int id);

        void Update(T entity);

        void Remove(int id);
    }
}
