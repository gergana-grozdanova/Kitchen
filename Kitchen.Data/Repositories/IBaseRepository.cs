using Kitchen.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Repositories
{
   public interface IBaseRepository<TEntity> where TEntity:BaseEntity
    {
        void  Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Save();
        void Dispose();
    }
}
