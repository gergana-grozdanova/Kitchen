using Kitchen.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.UoW
{
    class UnitOfWorkEF : IUnitOfWork
    {
        private readonly KitchenDbContext _dbContext;
        public UnitOfWorkEF(KitchenDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RollBack()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
