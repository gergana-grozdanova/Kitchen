using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Data
{
    public interface IBaseRepository<TEntity> : IReadable<TEntity>, IDeletable<TEntity>, ICreatable<TEntity>
         where TEntity : BaseEntity
    {
    }
}
