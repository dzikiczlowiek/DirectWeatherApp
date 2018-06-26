namespace DirectWeather.UnitTests.OpenWeatherMap.QueryHandlers
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.Services;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWeatherQueryHandlerFixtureElements : IFixtureElements
    {
        public IOpenWeatherMapApiClient ApiClient { get; } = Substitute.For<IOpenWeatherMapApiClient>();

        public ICountryCodesSource CountryCodesSource { get; } = Substitute.For<ICountryCodesSource>();

        public QueryResult<IWeatherInfo> Response { get; set; }

        public GetWeatherDataQuery Query { get; set; }

        public CountryCode CountryCode { get; internal set; }

        public WeatherData WeatherData { get; set; }
    }
}