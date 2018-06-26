namespace DirectWeather.UnitTests.OpenWeatherMap.JsonResponseMapperTests
{
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    using Xunit;

    public class MapTests : TestsBase, IClassFixture<MapFixture>
    {
        private readonly MapFixture mapFixture;

        public MapTests(MapFixture fixture)
        {
            mapFixture = fixture;
        }

        [Fact]
        public void mapper_should_properly_map_valid_success_weather_response()
        {
            mapFixture
                .ToTestJsonString(A.WeatherJsonData().SetTemperatureTo(123).SetHumidityTo(90).SetTimestamp(14500001))
                .Execute().AssertThat.ReceivedSuccessMessage().WeatherDataIsValid().TimestampIsProperlyMapped();
        }

        [Fact]
        public void mapper_should_properly_map_valid_error_response()
        {
            mapFixture.ToTestJsonString(A.ErrorJsonData("ERROR TEST MESSAGE")).Execute().AssertThat
                .ReceivedErrorMessage().MessageIsMapped();
        }
    }
}