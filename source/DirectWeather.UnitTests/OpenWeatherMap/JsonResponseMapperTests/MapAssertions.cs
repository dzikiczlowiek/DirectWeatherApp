namespace DirectWeather.UnitTests.OpenWeatherMap.JsonResponseMapperTests
{
    using FluentAssertions;

    public static class MapAssertions
    {
        public static MapFixtureElements WeatherDataIsValid(this MapFixtureElements elements)
        {
            elements.Result.Humidity.Should().Be(elements.InputJson.Humidity);
            elements.Result.Temperature.Should().Be(elements.InputJson.Temperature);
            return elements;
        }

        public static MapFixtureElements TimestampIsProperlyMapped(this MapFixtureElements elements)
        {
            elements.Result.DateTimestamp.Should().Be(elements.InputJson.Timestamp);
            return elements;
        }

        public static MapFixtureElements MessageIsMapped(this MapFixtureElements elements)
        {
            elements.Result.Message.Should().Be(elements.InputJson.Message);
            return elements;
        }

        public static MapFixtureElements ReceivedSuccessMessage(this MapFixtureElements elements)
        {
            elements.Result.Status.Should().Be("200");
            return elements;
        }

        public static MapFixtureElements ReceivedErrorMessage(this MapFixtureElements elements)
        {
            elements.Result.Status.Should().NotBe("200");
            return elements;
        }
    }
}