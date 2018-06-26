namespace DirectWeather.UnitTests.OpenWeatherMap.QueryHandlers
{
    using DirectWeather.Infrastructure.Dtos;

    using FluentAssertions;

    using NSubstitute;

    public static class GetWeatherQueryHandlerAssertions
    {
        public static GetWeatherQueryHandlerFixtureElements WeatherInfoIsProperlyMapped(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            var weatherInfo = elements.Response.Payload;
            weatherInfo.City.ToLower().Should().Be(elements.Query.City.ToLower());
            weatherInfo.Country.ToLower().Should().Be(elements.CountryCode.Name.ToLower());
            weatherInfo.TemperatureScale.Should().Be(elements.Query.TemperatureScale);
            weatherInfo.Temperature.Should().Be(elements.WeatherData.Temperature);
            weatherInfo.Humidity.Should().Be(elements.WeatherData.Humidity);
            return elements;
        }

        public static GetWeatherQueryHandlerFixtureElements CountryCodeWasSearched(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            elements.CountryCodesSource.Received(1).SearchByName(Arg.Is(elements.Query.Country));
            return elements;
        }

        public static GetWeatherQueryHandlerFixtureElements ApiClientWasQueried(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            elements.ApiClient.Received(1).GetWheaterForCity(
                Arg.Is(elements.Query.City),
                Arg.Is(elements.Query.Country),
                Arg.Is(elements.Query.TemperatureScale));
            return elements;
        }

        public static GetWeatherQueryHandlerFixtureElements QueryReturnsSuccess(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            elements.Response.Status.Should().Be(ApiResponseStatus.Ok);
            return elements;
        }

        public static GetWeatherQueryHandlerFixtureElements QueryReturnsError(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            elements.Response.Status.Should().Be(ApiResponseStatus.Error);
            return elements;
        }

        public static GetWeatherQueryHandlerFixtureElements QueryDidNotFoundData(
            this GetWeatherQueryHandlerFixtureElements elements)
        {
            elements.Response.Status.Should().Be(ApiResponseStatus.NotFound);
            return elements;
        }
    }
}