﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Kitchen.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
               routeTemplate: "api/{controller}/{action}/{id}", 
          defaults: new { id = RouteParameter.Optional }
       );
            MakeJsonDefaultFormat(config);
        }

        private static void MakeJsonDefaultFormat(HttpConfiguration config)
        {
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application / xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
       
    }
}
