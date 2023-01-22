using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Abstraction.Data
{
   public  interface IDeletable<TEntity> where TEntity : BaseEntity
    {
        void Delete(string id);
        void Delete(TEntity entityToDelete);
    }
}
