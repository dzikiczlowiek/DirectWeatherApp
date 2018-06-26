namespace DirectWeather.UnitTests.OpenWeatherMap.JsonResponseMapperTests
{
    using DirectWeather.Source.OpenWeatherMap;
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    public class MapFixture : FixtureBase<MapFixtureElements>
    {
        public MapFixture()
        {
            FixtureElements = new MapFixtureElements();
        }

        public MapFixture ToTestJsonString(JsonWeatherResponseBuilder input)
        {
            FixtureElements.InputJson = input;
            return this;
        }

        public MapFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Result = sut.Map(FixtureElements.InputJson);
            return this;
        }

        private JsonResponseMapper CreateSut()
        {
            var sut = new JsonResponseMapper();
            return sut;
        }
    }
}