using AutoMapper;
using Kitchen.Abstraction.Data;
using Kitchen.Models;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Decorators;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kitchen.Services
{
    public class FoodService : BaseService<Food, FoodDto>, IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository, IMapper mapper) : base(foodRepository, mapper)
        {
            _foodRepository = foodRepository;
        }
    }
}