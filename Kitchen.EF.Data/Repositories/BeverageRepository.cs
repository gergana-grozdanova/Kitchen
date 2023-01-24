using Kitchen.Abstraction.Data;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.EF.Data.Repositories
{
    class BeverageRepository : IBeverageRepository
    {
        public Task<IEnumerable<Beverage>> GetAll(Expression<Func<Beverage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Beverage> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
