namespace DirectWeather.Source.OpenWeatherMap
{
    using System.Configuration;

    using Autofac;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.Mappers;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Infrastructure.Services.Http;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.Services;

    public class OpenWeatherMapIoCSetup : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(
                    (OpenWeatherMapConfiguration)ConfigurationManager.GetSection(OpenWeatherMapConfiguration.Name))
                .AsSelf()
                .As<IHttpClientApiConfiguration>().SingleInstance();
            builder.RegisterType<CountryCodesSource>().As<ICountryCodesSource>().InstancePerLifetimeScope();
            builder.RegisterType<JsonResponseMapper>().As<IStringMapper<WeatherData>>().SingleInstance();
            builder.RegisterType<OpenWeatherMapQueryHandler>()
                .As<IQueryHandler<GetWeatherDataQuery, QueryResult<IWeatherInfo>>>().InstancePerLifetimeScope();
            builder.RegisterType<OpenWeatherMapApiClient>().As<IOpenWeatherMapApiClient>().SingleInstance();
        }
    }
}