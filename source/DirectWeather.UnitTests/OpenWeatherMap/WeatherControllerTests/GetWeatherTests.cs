namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using System.Web.Http;

    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    using Xunit;

    public class GetWeatherTests : TestsBase, IClassFixture<GetWeatherFixture>
    {
        private readonly GetWeatherFixture fixture;

        public GetWeatherTests(GetWeatherFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ensure_that_query_dispatcher_was_queried_with_proper_query()
        {
            var request = new WeatherRequest { Country = "Poland", City = "Warsaw" };
            fixture.Accept(request).Execute().AssertThat.ValidWeatherQueryWasSendToQueryDispatcher();
        }

        [Fact]
        public void ensure_that_query_result_was_utilized_in_response_builder_mapping_method()
        {
            var request = new WeatherRequest { Country = "Poland", City = "Warsaw" };
            fixture.Accept(request).Execute().AssertThat.ValidWeatherQueryWasSendToQueryDispatcher();
        }
    }

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public GetWeatherFixtureElements()
        {
            QueryDispatcher.ProcessAsync(Arg.Do<GetWeatherDataQuery>(q => Query = q));
        }

        public IResponseBuilder ResponseBuilder { get; set; } = Substitute.For<IResponseBuilder>();

        public IQueryDispatcher QueryDispatcher { get; set; } = Substitute.For<IQueryDispatcher>();

        public IHttpActionResult Response { get; set; }

        public WeatherRequest Request { get; set; }

        public GetWeatherDataQuery Query { get; set; }

        public SourceResponse<IWeatherInfo> QueryResult { get; set; }
    }

    public static class GetWeatherAssertions
    {
        public static GetWeatherFixtureElements ValidWeatherQueryWasSendToQueryDispatcher(
            this GetWeatherFixtureElements elements)
        {
            elements.QueryDispatcher.Received(1).ProcessAsync(Arg.Is(elements.Query));
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
