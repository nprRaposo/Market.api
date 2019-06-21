using Market.Api.Domain.Models;
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
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> Get(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            IEnumerable<string> includeProperties = null)
        {
            var props = includeProperties == null ? new List<string> { "Category" } : includeProperties.Append("Category");

            return await base.Get(filter, orderBy, props);
        }
    }
}
