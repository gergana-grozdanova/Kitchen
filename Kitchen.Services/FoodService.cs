using AutoMapper;
using Kitchen.Abstraction.Data;
using Kitchen.Models;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class FoodService : BaseService<Food, FoodDto>, IFoodService
    {
        public FoodService(IBaseRepository<Food> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
        }
    }
}