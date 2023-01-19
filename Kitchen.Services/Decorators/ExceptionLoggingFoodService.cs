using Kitchen.Logging;
using Kitchen.Models;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services.Decorators
{
   public  class ExceptionLoggingFoodService : ExceptionLoggingBaseService<Food, FoodDto>, IFoodService
    {
        public ExceptionLoggingFoodService(FoodService wrappedService, ILogger logger) : base(wrappedService, logger)
        {
        }
    }
}
