using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Repositories.Food
{
   public class FoodRepository : BaseRepository<Entities.Food>, IFoodRepository
    {
        public FoodRepository(KitchenDbContext dbContext) : base(dbContext)
        {
        }
    }
}
