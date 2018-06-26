namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    using NSubstitute;

    using Xunit;

    public class GetWeatherTests : TestsBase, IClassFixture<GetWeatherFixture>
    {
        private readonly GetWeatherFixture getWeatherFixture;

        public GetWeatherTests(GetWeatherFixture getWeatherFixture)
        {
            this.getWeatherFixture = getWeatherFixture;
        }

        [Fact]
        public void ensure_that_query_dispatcher_was_queried_with_proper_query()
        {
            getWeatherFixture
                .Accept(A.WeatherRequest().ForCity("Warsaw").InCountry("Poland"))
                .Execute()
                .AssertThat
                    .ValidWeatherQueryWasSendToQueryDispatcher();
        }

        [Fact]
        public void ensure_that_query_result_was_utilized_in_response_builder_mapping_method()
        {
            getWeatherFixture
                .Accept(A.WeatherRequest().ForCity("Warsaw").InCountry("Poland"))
                .AndTheResultForTheQueryIs(A.SuccessWeatherQueryResult())
                .Execute()
                .AssertThat
                    .ValidWeatherQueryWasSendResponseBuilder();
        }
    }

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
            FixtureElements.QueryDispatcher.ProcessAsync(Arg.Is<GetWeatherDataQuery>(q => q.Country == FixtureElements.Request.Country && q.City == FixtureElements.Request.City)).Returns(queryResult);
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
