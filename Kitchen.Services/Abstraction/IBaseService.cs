using Kitchen.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Abstraction
{
    public interface IBaseService<TEntity> where TEntity:BaseEntity
    {
         TEntity Create(TEntity entity);
         TEntity Update(TEntity entity);
         void Delete(string id);
         TEntity GetById(string id);
         List<TEntity> GetAll();
    }
}
