namespace DirectWeather.UnitTests.OpenWeatherMap.CountryCodeSourceTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    using DirectWeather.Tests.Core;

    using Xunit;

    public class SearchByNameTests : TestsBase, IClassFixture<SearchByNameFixture>
    {
        private readonly SearchByNameFixture searchByNameFixture;

        public SearchByNameTests(SearchByNameFixture searchByNameFixture)
        {
            this.searchByNameFixture = searchByNameFixture;
        }

        [Fact]
        public void ensure_that_method_returns_null_when_code_not_found()
        {
            searchByNameFixture
                .Term("LOREM_IPSUM")
                .Execute()
                .AssertThat
                    .CodeNotFound();
        }

        [Theory]
        [ClassData(typeof(CountryCodesTestData))]
        public void ensure_that_dictionary_contains_ISO_3166_country_code(string name, string code)
        {
            searchByNameFixture
                .Term(name)
                .Execute()
                .AssertThat
                    .FoundCode()
                    .CodeIs(code);
        }

        public class CountryCodesTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                using (var sr = new StringReader(TestData.country_codes))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        var code = parts[1].ToUpper();
                        var name = parts[0].ToUpper();

                        yield return new object[] { name, code };
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}