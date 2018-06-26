namespace DirectWeather.UnitTests.OpenWeatherMap.OpenWeatherMapApiClientTests
{
    using System.Net.Http;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.Mappers;
    using DirectWeather.Infrastructure.Services.Http;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWheaterForCityFixtureElements : IFixtureElements
    {
        public GetWheaterForCityFixtureElements()
        {
            HttpClient = new HttpClient(HttpMessageHandler) { BaseAddress = new System.Uri("http://contoso.com") };
        }

        public IStringMapper<WeatherData> JsonResponseMapper = Substitute.For<IStringMapper<WeatherData>>();

        public IHttpClientApiConfiguration ApiConfiguration = Substitute.For<IHttpClientApiConfiguration>();

        public FakeHttpMessageHandler HttpMessageHandler { get; } = new FakeHttpMessageHandler();

        public HttpClient HttpClient { get; }

        public WeatherData Response { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public TemperatureScale TemperatureScale { get; set; }
    }
}