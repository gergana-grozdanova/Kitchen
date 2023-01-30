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
    public class BaseRepositoryEF<TEntity> : IBaseRepository<TEntity>
         where TEntity : BaseEntity
    {
        protected readonly KitchenDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;
        public BaseRepositoryEF(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Delete(string id)
        {
            TEntity entity = entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                entities.Remove(entity);
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                entities.Attach(entityToDelete);
            }
            entities.Remove(entityToDelete);
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
