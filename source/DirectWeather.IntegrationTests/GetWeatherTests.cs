namespace DirectWeather.IntegrationTests
{
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    using Xunit;

    public class GetWeatherTests : TestsBase, IClassFixture<GetWeatherFixture>
    {
        private readonly GetWeatherFixture getWeatherFixture;

        public GetWeatherTests(GetWeatherFixture getWeatherFixture)
        {
            this.getWeatherFixture = getWeatherFixture;
        }

        [Theory]
        [InlineData("Poland", "Warsaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        public void confront_get_weather_action_with_real_data_for_specific_locations(string country, string city)
        {
            getWeatherFixture.WireIoC().PrepareReqest(A.WeatherRequest().ForCity(city).InCountry(country)).Execute();
        }
    }
}