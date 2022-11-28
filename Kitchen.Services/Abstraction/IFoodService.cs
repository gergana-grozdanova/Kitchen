using Kitchen.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Abstraction
{
    public interface IFoodService:IBaseService<Food>
    {
        IEnumerable<Food> GetFoodByName(string name);
    }
}
