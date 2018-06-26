namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWeatherFixture : FixtureBase<GetWeatherFixtureElements>
    {
        public GetWeatherFixture Accept(WeatherRequest request)
        {
            FixtureElements = new GetWeatherFixtureElements();
            FixtureElements.Request = request;
            return this;
        }

        public GetWeatherFixture AndTheResultForTheQueryIs(SourceResponse<IWeatherInfo> queryResult)
        {
            FixtureElements.QueryResult = queryResult;
            FixtureElements.QueryDispatcher.ProcessAsync(
                    Arg.Is<GetWeatherDataQuery>(
                        q => q.Country == FixtureElements.Request.Country && q.City == FixtureElements.Request.City))
                .Returns(queryResult);
            return this;
        }

        public GetWeatherFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Response = sut.GetWeather(FixtureElements.Request).Result;
            return this;
        }

        private WeatherController CreateSut()
        {
            var sut = new WeatherController(FixtureElements.ResponseBuilder, FixtureElements.QueryDispatcher);
            return sut;
        }
    }
}