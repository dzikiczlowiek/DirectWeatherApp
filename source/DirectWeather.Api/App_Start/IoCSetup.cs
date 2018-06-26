// ReSharper disable once CheckNamespace

namespace DirectWeather.Api.App_Start
{
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Infrastructure.Services.Http;
    using DirectWeather.Infrastructure.Services.Logging;
    using DirectWeather.Source.OpenWeatherMap;

    using NodaTime;

    public static class IoCSetup
    {
        public static void WireEverything()
        {
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<LoggingModule>();
            builder.RegisterType<AppLogger>().As<IAppLogger>().SingleInstance();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().InstancePerRequest();

            builder.RegisterInstance(SystemClock.Instance).As<IClock>().SingleInstance();

            builder.RegisterType<HttpClientBuilder>().As<IHttpClientBuilder>().SingleInstance();
            builder.Register(context => context.Resolve<IHttpClientBuilder>().Build()).AsSelf().SingleInstance();

            builder.RegisterType<ResponseBuilder>().AsSelf().SingleInstance();
            builder.RegisterModule<OpenWeatherMapIoCSetup>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}