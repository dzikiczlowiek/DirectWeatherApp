namespace DirectWeather.IntegrationTests
{
    using System.Web.Http;

    using Autofac;

    using DirectWeather.Api.Models;
    using DirectWeather.Tests.Core;

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public IContainer Container { get; set; }

        public WeatherRequest Request { get; set; }

        public IHttpActionResult Response { get; set; }

        public ILifetimeScope LifetimeScope { get; set; }
    }
}