namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using DirectWeather.Api.ActionResults;
    using DirectWeather.Api.Models;

    using FluentAssertions;

    using NSubstitute;

    public static class GetWeatherAssertions
    {
        public static GetWeatherFixtureElements ValidWeatherQueryWasSendToQueryDispatcher(
            this GetWeatherFixtureElements elements)
        {
            elements.QueryDispatcher.Received(1).ProcessAsync(Arg.Is(elements.Query));
            return elements;
        }

        public static GetWeatherFixtureElements ValidWeatherQueryWasSendResponseBuilder(
            this GetWeatherFixtureElements elements)
        {
            elements.ResponseBuilder.Received(1).MapWeatherDataResponse(Arg.Is(elements.QueryResult));
            return elements;
        }

        public static GetWeatherFixtureElements ReturnsValidApiResponse(this GetWeatherFixtureElements elements)
        {
            var apiResponse = (ApiResponse<Weather>)elements.Response;
            apiResponse.Payload.Temperature.Value.Should().Be(elements.MappedResponse.Payload.Temperature.Value);
            apiResponse.Payload.Temperature.Format.Should().Be(elements.MappedResponse.Payload.Temperature.Format);
            apiResponse.Payload.Humidity.Should().Be(elements.MappedResponse.Payload.Humidity);
            apiResponse.Payload.Location.City.Should().Be(elements.MappedResponse.Payload.Location.City);
            apiResponse.Payload.Location.Country.Should().Be(elements.MappedResponse.Payload.Location.Country);
            return elements;
        }
    }
}