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
        public async Task<TEntity> Create(TEntity entity)
        {
            entities.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(string id)
        {
            TEntity entity = await entities.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                entities.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await entities.FirstOrDefaultAsync(e=>e.Id==id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var oldEntity = await entities.FindAsync(entity.Id);
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
