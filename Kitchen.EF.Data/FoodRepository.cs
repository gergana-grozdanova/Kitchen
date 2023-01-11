using Kitchen.Abstraction.Data;
using Kitchen.EF.Data;
using Kitchen.EF.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.EF
{
   public class FoodRepository : BaseRepositoryEF<Models.Food>, IFoodRepository
    {
        public FoodRepository(KitchenDbContext dbContext) : base(dbContext)
        {
        }
    }
}
