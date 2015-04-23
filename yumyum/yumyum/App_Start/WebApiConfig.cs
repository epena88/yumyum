using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace yumyum
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            return config;           

        }
    }
}
