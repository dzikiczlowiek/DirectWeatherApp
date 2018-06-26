namespace DirectWeather.IntegrationTests
{
    using System;

    using Autofac;

    using DirectWeather.Api.App_Start;
    using DirectWeather.Api.Controllers;
    using DirectWeather.Api.Models;
    using DirectWeather.Tests.Core;

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
}