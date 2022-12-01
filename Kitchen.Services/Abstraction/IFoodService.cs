using Kitchen.Data.Entities;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Abstraction
{
    public interface IFoodService:IBaseService<Food, FoodDto> 
    {
    }
}
