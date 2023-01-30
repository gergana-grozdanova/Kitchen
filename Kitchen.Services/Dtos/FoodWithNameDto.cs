using Kitchen.Abstraction.Services;
using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Dtos
{
  public  class FoodWithNameDto:BaseDto
    {
        public string  Name { get; set; }

        public static Expression<Func<Food, FoodWithNameDto>> UserSelector
        {
            get
            {
                return food => new FoodWithNameDto()
                {
                   Id=food.Id,
                   Name=food.Name
                };
            }
        }
    }
}
