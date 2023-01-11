using AutoMapper;
using Kitchen.Models;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Services
{
  public  class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Food, FoodWithNameDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
        }
    }
}
