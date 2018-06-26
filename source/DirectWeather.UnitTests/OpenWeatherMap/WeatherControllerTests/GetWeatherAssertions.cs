namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
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
    }
}