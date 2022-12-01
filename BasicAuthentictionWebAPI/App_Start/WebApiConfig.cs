using BasicAuthentictionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web.Http;

namespace BasicAuthentictionWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //To enable basic authentication for entire webapplication
            config.Filters.Add(new BasicAuthenticationAttribute());
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/Employee/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
