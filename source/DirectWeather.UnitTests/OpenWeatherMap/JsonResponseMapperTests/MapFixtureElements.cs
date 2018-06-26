namespace DirectWeather.UnitTests.OpenWeatherMap.JsonResponseMapperTests
{
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    public class MapFixtureElements : IFixtureElements
    {
        public JsonWeatherResponseBuilder InputJson { get; set; }

        public WeatherData Result { get; set; }
    }
}