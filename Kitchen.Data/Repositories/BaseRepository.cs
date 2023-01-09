using Kitchen.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Repositories
{
   public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly KitchenDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;
        public  BaseRepository(KitchenDbContext dbContext)
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
            TEntity entity =  entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                entities.Remove(entity);              
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                entities.Attach(entityToDelete);
            }
            entities.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await entities.FirstOrDefaultAsync(e=>e.Id==id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var oldEntity =  entities.FirstOrDefault(e=>e.Id==entity.Id);
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
