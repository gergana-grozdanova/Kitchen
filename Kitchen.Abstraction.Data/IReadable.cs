using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Data
{
   public interface IReadable<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);
    }
}
