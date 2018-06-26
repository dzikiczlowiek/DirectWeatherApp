namespace DirectWeather.UnitTests.OpenWeatherMap.CountryCodeSourceTests
{
    using DirectWeather.Source.OpenWeatherMap.Services;
    using DirectWeather.Tests.Core;

    public class SearchByNameFixture : FixtureBase<SearchByNameFixtureElements>
    {
        public SearchByNameFixture()
        {
            FixtureElements = new SearchByNameFixtureElements();
        }

        public SearchByNameFixture Term(string countryNameTerm)
        {
            FixtureElements.InputTerm = countryNameTerm;
            return this;
        }

        public SearchByNameFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Result = sut.SearchByName(FixtureElements.InputTerm);
            return this;
        }

        private CountryCodesSource CreateSut()
        {
            var sut = new CountryCodesSource();
            return sut;
        }
    }
}