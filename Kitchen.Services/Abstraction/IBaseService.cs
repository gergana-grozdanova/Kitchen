using Kitchen.Models;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Abstraction
{
    public interface IBaseService<TEntity,TDto> where TEntity:BaseEntity where TDto:BaseDto
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(string id);

         Task<TDto> GetById(string id);

         Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity,bool>> expression);
         void Dispose();
    }
}
