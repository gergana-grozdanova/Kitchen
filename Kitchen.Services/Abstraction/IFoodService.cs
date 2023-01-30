using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Models;
using Kitchen.Abstraction.Services.Interfaces;

namespace Kitchen.Services.Abstraction
{
    public interface IFoodService:IReadService<Food,FoodDto>,IDeleteService,ICreateService<Food>
    {
    }
}
