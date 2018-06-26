namespace DirectWeather.UnitTests.OpenWeatherMap
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap;
    using DirectWeather.Tests.Core;

    using FluentAssertions;

    using Xunit;

    public class ExtensionsTests : TestsBase
    {
        [Theory]
        [InlineData(TemperatureScale.Kelvin, "kelvin")]
        [InlineData(TemperatureScale.Fahrenheit, "imperial")]
        [InlineData(TemperatureScale.Celsius, "metric")]
        public void ensure_that_every_value_from_temperature_scale_has_its_counterpart_for_open_weather_map_api(
            TemperatureScale temperatureScale,
            string owmValue)
        {
            temperatureScale.ToText().Should().Be(owmValue);
        }
    }
}