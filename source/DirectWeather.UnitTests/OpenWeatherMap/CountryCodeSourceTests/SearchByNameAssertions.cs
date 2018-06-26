namespace DirectWeather.UnitTests.OpenWeatherMap.CountryCodeSourceTests
{
    using FluentAssertions;

    public static class SearchByNameAssertions
    {
        public static SearchByNameFixtureElements CodeNotFound(this SearchByNameFixtureElements elements)
        {
            elements.Result.Should().BeNull();
            return elements;
        }

        public static SearchByNameFixtureElements FoundCode(this SearchByNameFixtureElements elements)
        {
            elements.Result.Should().NotBeNull($"Could not find code for {elements.InputTerm}");
            return elements;
        }

        public static SearchByNameFixtureElements CodeIs(this SearchByNameFixtureElements elements, string code)
        {
            elements.Result.Code.Should().Be(code);
            return elements;
        }
    }
}