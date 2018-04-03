using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Api01
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var formater = new JsonMediaTypeFormatter();
            formater.Indent = true;
            
            config.Formatters.Clear();
            config.Formatters.Add(formater);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
