using Kitchen.Data.Entities;
using Kitchen.Services.Abstraction;
using Kitchen.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kitchen.Api.Controllers
{
    public class FoodController : ApiController
    {
        private readonly IFoodService _foodService;
       
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
       
        [HttpGet]
        public async  Task<IEnumerable<FoodDto>> GetAll()
        {
        
            return await _foodService.GetAll();
        }
        [HttpGet]
        public async Task<FoodDto> GetById(string id)
        {
            var food = await _foodService.GetById(id);
            if (food == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return food;
        }

       

        [HttpPost]
        public async  Task<FoodDto> Create(Food food)
        {
           
          return await _foodService.Create(food);
          
        }

        [HttpPost]
        public async Task Delete(string id)
        {
           await _foodService.Delete(id);

        }
        //[HttpPost]
        //public IEnumerable<FoodDto> Search(string name)
        //{
        //    return  _foodService.GetFoodByName(name);
        //}
        //public HttpResponseMessage GetFood([FromUri] SearchCriteriaModel crit)
        //{
        //// Validate and clean crit object
        //var list = ...(crit);
        //    return list;
        //}
    }
}
