using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TalkNotesFront
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true; // Mostly to show that we can intercept this in the container
            traceWriter.MinimumLevel = System.Web.Http.Tracing.TraceLevel.Debug;

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
