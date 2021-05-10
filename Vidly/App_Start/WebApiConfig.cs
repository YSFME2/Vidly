using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json.Serialization;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
