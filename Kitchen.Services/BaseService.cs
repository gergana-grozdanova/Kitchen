using Kitchen.Data;
using Kitchen.Data.Entities;
using Kitchen.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class BaseService<TEntity>:IBaseService<TEntity> where TEntity:BaseEntity
    {
        protected readonly KitchenDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;
        protected BaseService(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }
        public TEntity Create(TEntity entity)
        {
             entities.Add(entity);
             _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(string id)
        {
            TEntity entity =  entities.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
            entities.Remove(entity);
            _dbContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity GetById(string id)
        {
            return entities
                .FirstOrDefault(e => e.Id == id);
        }

        public TEntity Update(TEntity entity)
        {
            var oldEntity = entities.Find(entity.Id);          
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
