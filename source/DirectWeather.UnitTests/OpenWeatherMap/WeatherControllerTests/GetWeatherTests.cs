namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using System.Web.Http;

    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.QueryHandlers;
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
            
        }
    }

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public IResponseBuilder ResponseBuilder { get; set; } = Substitute.For<IResponseBuilder>();

        public IQueryDispatcher QueryDispatcher { get; set; } = Substitute.For<IQueryDispatcher>();

        public IHttpActionResult Response { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }

    public class GetWeatherFixture : FixtureBase<GetWeatherFixtureElements>
    {
        public GetWeatherFixture Execute()
        {
            var sut = CreateSut();
       //     FixtureElements.Response = sut.GetWeather(FixtureElements.Country, FixtureElements.City).Result;
            return this;
        }

        private WeatherController CreateSut()
        {
            var sut = new WeatherController(FixtureElements.ResponseBuilder, FixtureElements.QueryDispatcher);
            return sut;
        }
    }
}
