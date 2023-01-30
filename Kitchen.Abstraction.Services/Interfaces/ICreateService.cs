using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Abstraction.Services.Interfaces
{
   public interface ICreateService<TEntity> where TEntity:BaseEntity
    {
        void Create(TEntity entity);
    }
}
