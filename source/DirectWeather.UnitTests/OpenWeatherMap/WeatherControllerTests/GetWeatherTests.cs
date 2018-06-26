namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
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
    }

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public ResponseBuilder ResponseBuilder { get; set; }

        public IQueryDispatcher QueryDispatcher { get; set; } = Substitute.For<IQueryDispatcher>();
    }

    public class GetWeatherFixture : FixtureBase<GetWeatherFixtureElements>
    {
        private WeatherController CreateSut()
        {
        }
    }

}
