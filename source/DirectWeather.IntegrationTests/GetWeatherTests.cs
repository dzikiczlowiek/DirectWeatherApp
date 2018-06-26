namespace DirectWeather.IntegrationTests
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Autofac;

    using DirectWeather.Api.App_Start;
    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Services.Http;
    using DirectWeather.Source.OpenWeatherMap;
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    using Xunit;

    public class GetWeatherTests : TestsBase, IClassFixture<GetWeatherFixture>
    {
        private readonly GetWeatherFixture getWeatherFixture;

        public GetWeatherTests(GetWeatherFixture getWeatherFixture)
        {
            this.getWeatherFixture = getWeatherFixture;
        }

        [Theory]
        [InlineData("Poland", "Warsaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        public void confront_get_weather_action_with_real_data_for_specific_locations(string country, string city)
        {
            getWeatherFixture
                .WireIoC()
                .PrepareReqest(A.WeatherRequest().ForCity(city).InCountry(country))
                .Execute();
        }
    }

    public class GetWeatherFixture : FixtureBase<GetWeatherFixtureElements>, IDisposable
    {
        public GetWeatherFixture WireIoC()
        {
            FixtureElements = new GetWeatherFixtureElements();
            var builder = IoCSetup.WireEverything();
            var container = builder.Build();
            FixtureElements.Container = container;
            FixtureElements.LifetimeScope = container.BeginLifetimeScope();
            return this;
        }

        public GetWeatherFixture PrepareReqest(WeatherRequest request)
        {
            FixtureElements.Request = request;
            return this;
        }

        public GetWeatherFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Response = sut.GetWeather(FixtureElements.Request).Result;
            return this;
        }

        public void Dispose()
        {
            FixtureElements.LifetimeScope.Dispose();
            FixtureElements.Container.Dispose();
        }

        private WeatherController CreateSut() => FixtureElements.LifetimeScope.Resolve<WeatherController>();
    }

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public IContainer Container { get; set; }

        public WeatherRequest Request { get; set; }

        public IHttpActionResult Response { get; set; }

        public ILifetimeScope LifetimeScope { get; set; }
    }
}
