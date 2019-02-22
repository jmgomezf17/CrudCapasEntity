﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrudCapas.ApiRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            ConfigureJsonFormatter(config);


            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }

        private static void ConfigureJsonFormatter(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;

            // Cambiar capitalización a las letras
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Ignorar valores nulos
            jsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            // Cambiar formato de fecha
            jsonFormatter.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;

            // Cambiar la cultura
            //jsonFormatter.SerializerSettings.Culture = new CultureInfo("en-ES");
        }
    }
}
