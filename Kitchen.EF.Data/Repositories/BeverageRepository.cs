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
        protected readonly KitchenDbContext _dbContext;
        public BeverageRepository(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Beverage>> GetAll(Expression<Func<Beverage, bool>> expression)
        {
            return await Task.FromResult(_dbContext.Beverages);
        }

        public async Task<Beverage> GetById(string id)
        {
            return await _dbContext.Beverages.FindAsync(id);
        }
    }
}
