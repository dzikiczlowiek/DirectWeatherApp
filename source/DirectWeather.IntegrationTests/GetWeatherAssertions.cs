namespace DirectWeather.IntegrationTests
{
    using DirectWeather.Api.ActionResults;
    using DirectWeather.Api.Models;

    using FluentAssertions;

    public static class GetWeatherAssertions
    {
        public static GetWeatherFixtureElements ResponseIsFrom(this GetWeatherFixtureElements elements, string country, string city)
        {
            var apiResponse = (ApiResponse<Weather>)elements.Response;
            apiResponse.Payload.Location.City.Should().Be(city);
            apiResponse.Payload.Location.Country.Should().Be(country);
            return elements;
        }
    }
}