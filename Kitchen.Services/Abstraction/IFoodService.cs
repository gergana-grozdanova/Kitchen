using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Models;

namespace Kitchen.Services.Abstraction
{
    public interface IFoodService:IBaseService<Food, FoodDto> 
    {
    }
}
