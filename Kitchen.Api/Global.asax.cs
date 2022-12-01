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
using Microsoft.Practices.Unity;
using Autofac;
using System.Reflection;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Kitchen.Data;
using Kitchen.Data.Repositories.Food;
using AutoMapper;

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
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<KitchenDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<FoodRepository>().As<IFoodRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FoodService>().As<IFoodService>().InstancePerLifetimeScope();


            //MapperConfiguration config = AutoMapperConfig.Configure();
            //IMapper mapper = config.CreateMapper();
            //builder.Register(ctx=>ctx.InjectProperties(mapper));

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
           
        }
    }
}
