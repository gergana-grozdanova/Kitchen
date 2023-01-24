using Kitchen.Abstraction.Data;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.EF.Data.Repositories
{
    class CreateRepository<TEntity> : ICreatable<TEntity> where TEntity : BaseEntity
    {
        protected readonly KitchenDbContext _dbContext;
        protected readonly DbSet<TEntity> entities;
        public CreateRepository(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            entities.Add(entity);

        }

    }
}
