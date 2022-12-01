using Kitchen.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Kitchen.Data.Repositories.Food;
using AutoMapper;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Kitchen.Services.Dtos;
using Kitchen.Data.Entities;

namespace Kitchen.Test
{
    [TestClass]
    public class FoodServiceTests
    {
        [TestMethod]
        public void GetAll_Returns_TheCorrect_NumberFood()
        {
            var myProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var mockRepo = new Mock<IFoodRepository>();
            var food = new List<Food> ();
            food.Add(new Food());
            food.Add(new Food());
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(food);

            FoodService service = new FoodService(mockRepo.Object,mapper);

            var actualResult= service.GetAll().GetAwaiter().GetResult().Count();
            var expectedResult = 2;
            Assert.AreEqual(expectedResult, actualResult);



        }

        [TestMethod]
        public void GetById_Returns_TheCorrect_Food()
        {
            var myProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            var mockRepo = new Mock<IFoodRepository>();
            var food = new Food() { Id = "test12345", Name = "Test" };              
            mockRepo.Setup(x => x.GetById("test12345")).ReturnsAsync(food);

            FoodService service = new FoodService(mockRepo.Object, mapper);

            var actualResult = service.GetById("test12345").GetAwaiter().GetResult().Name;
            var expectedResult = "Test";
            Assert.AreEqual(expectedResult, actualResult);



        }
    }
}
