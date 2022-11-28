using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using Kitchen.Services.Abstraction;
using Kitchen.Services;

namespace Kitchen.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var container = new Container();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
          
            //container.Register<IFoodService, FoodService >(Lifestyle.Scoped);

           
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
            //    new SimpleInjectorWebApiDependencyResolver(container);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialise();
           
        }
    }
}
