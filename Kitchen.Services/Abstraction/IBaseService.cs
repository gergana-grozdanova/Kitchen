using Kitchen.Data.Entities;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Abstraction
{
    public interface IBaseService<TEntity,TDto> where TEntity:BaseEntity where TDto:BaseDto
    {
          Task<TDto> Create(TEntity entity);

         Task<TDto> Update(TEntity entity);

         Task Delete(string id);

         Task<TDto> GetById(string id);

         Task<IEnumerable<TDto>> GetAll();
    }
}
