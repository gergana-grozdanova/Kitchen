using Kitchen.Data.Entities;
using Kitchen.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public Food[] GetAll()
        {
        
            return _foodService.GetAll().ToArray();
        }
        [HttpGet]
        public Food GetById(string id)
        {
            var food = _foodService.GetById(id);
            if (food == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return food;
        }

        [HttpPost]
        public Food Create(Food food)
        {
            var created = new Food();
            try
            {
           created = _foodService.Create(food);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
            return created;
        }

        [HttpDelete]
        public void Delete(string id)
        {
            _foodService.Delete(id);

        }
        [HttpPost]
        public IEnumerable<Food> Search(string name)
        {
            return _foodService.GetFoodByName(name);
        }
        //public HttpResponseMessage GetFood([FromUri] SearchCriteriaModel crit)
        //{
        //// Validate and clean crit object
        //var list = ...(crit);
        //    return list;
        //}
    }
}
