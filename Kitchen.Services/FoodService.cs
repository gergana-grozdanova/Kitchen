using Kitchen.Data;
using Kitchen.Data.Entities;
using Kitchen.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen.Services
{
    public class FoodService : BaseService<Food>,IFoodService
    {
        public FoodService(KitchenDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Food> GetFoodByName(string name)
        {
            return _dbContext.Food.Where(f => f.Name == name);
        }
    }
}