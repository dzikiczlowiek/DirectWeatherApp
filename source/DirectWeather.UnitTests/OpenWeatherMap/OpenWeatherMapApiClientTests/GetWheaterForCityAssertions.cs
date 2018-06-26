namespace DirectWeather.UnitTests.OpenWeatherMap.OpenWeatherMapApiClientTests
{
    using System.Web;

    using DirectWeather.Source.OpenWeatherMap;

    using FluentAssertions;

    using NSubstitute;

    public static class GetWheaterForCityAssertions
    {
        public static GetWheaterForCityFixtureElements ApiGetUrlIsProperlyGeneratedUsingWeatherRequest(
            this GetWheaterForCityFixtureElements elements)
        {
            var parameters = HttpUtility.ParseQueryString(elements.HttpMessageHandler.LastRequest.RequestUri.Query);
            parameters["q"].Should().Be($"{elements.City},{elements.CountryCode}");
            parameters["APPID"].Should().Be(elements.ApiConfiguration.ApiKey);
            parameters["units"].Should().Be(elements.TemperatureScale.ToText());
            return elements;
        }

        public static GetWheaterForCityFixtureElements HttpResponseGoesThroughMapper(
            this GetWheaterForCityFixtureElements elements)
        {
            elements.JsonResponseMapper.Received(1).Map(Arg.Is(elements.HttpMessageHandler.StringResponse));
            return elements;
        }
    }
}