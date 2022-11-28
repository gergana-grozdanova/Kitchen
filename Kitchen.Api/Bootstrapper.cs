using System.Web.Http;
using System.Web.Mvc;
using Kitchen.Api.Controllers;
using Kitchen.Services;
using Kitchen.Services.Abstraction;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace Kitchen.Api
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
           

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

             container.RegisterType<IFoodService, FoodService>();
            //container.RegisterType<ApiController, FoodController>("Food");
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}