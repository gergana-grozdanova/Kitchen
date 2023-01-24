using Kitchen.Abstraction.Data;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.EF.Data.Repositories
{
    class ReadRepository<TEntity> : IReadable<TEntity> where TEntity : BaseEntity
    {
        protected readonly KitchenDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;
        public ReadRepository(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await entities.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
