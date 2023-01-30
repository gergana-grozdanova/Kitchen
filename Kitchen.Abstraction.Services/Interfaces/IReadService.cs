using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Services.Interfaces
{
   public interface IReadService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        Task<TDto> GetById(string id);

        Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>> expression);
    }
}
