namespace DirectWeather.UnitTests.OpenWeatherMap.OpenWeatherMapApiClientTests
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Services;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWheaterForCityFixture : FixtureBase<GetWheaterForCityFixtureElements>
    {
        public GetWheaterForCityFixture()
        {
            FixtureElements = new GetWheaterForCityFixtureElements();
        }

        public GetWheaterForCityFixture ForCity(string city)
        {
            FixtureElements.City = city;
            return this;
        }

        public GetWheaterForCityFixture WithCountryCode(string countryCode)
        {
            FixtureElements.CountryCode = countryCode;
            return this;
        }

        public GetWheaterForCityFixture ResultIn(TemperatureScale temperatureScale)
        {
            FixtureElements.TemperatureScale = temperatureScale;
            return this;
        }

        public GetWheaterForCityFixture ApiReponseMappedToDefaultValue() => ApiReponseMappedTo(new WeatherData());

        public GetWheaterForCityFixture ApiReponseMappedTo(WeatherData weatherData)
        {
            FixtureElements.JsonResponseMapper.Map(Arg.Any<string>()).Returns(weatherData);
            return this;
        }

        public GetWheaterForCityFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Response = sut.GetWheaterForCity(
                FixtureElements.City,
                FixtureElements.CountryCode,
                FixtureElements.TemperatureScale).Result;
            return this;
        }

        private OpenWeatherMapApiClient CreateSut()
        {
            var sut = new OpenWeatherMapApiClient(
                FixtureElements.HttpClient,
                FixtureElements.JsonResponseMapper,
                FixtureElements.ApiConfiguration);
            return sut;
        }
    }
}