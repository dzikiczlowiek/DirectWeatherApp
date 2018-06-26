namespace DirectWeather.UnitTests.OpenWeatherMap.CountryCodeSourceTests
{
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Tests.Core;

    public class SearchByNameFixtureElements : IFixtureElements
    {
        public string InputTerm { get; set; }

        public CountryCode Result { get; set; }
    }
}