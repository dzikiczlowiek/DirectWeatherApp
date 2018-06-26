namespace DirectWeather.Api
{
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Microsoft.Web.Http.Routing;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintResolver =
                new DefaultInlineConstraintResolver
                    {
                        ConstraintMap =
                            {
                                ["apiVersion"] =
                                typeof(ApiVersionRouteConstraint)
                            }
                    };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning(o => o.ReportApiVersions = true);

            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}