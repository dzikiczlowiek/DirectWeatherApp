namespace DirectWeather.UnitTests.OpenWeatherMap.QueryHandlers
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWeatherQueryHandlerFixture : FixtureBase<GetWeatherQueryHandlerFixtureElements>
    {
        public GetWeatherQueryHandlerFixture For(GetWeatherDataQuery query)
        {
            FixtureElements = new GetWeatherQueryHandlerFixtureElements();
            FixtureElements.Query = query;
            return this;
        }

        public GetWeatherQueryHandlerFixture ApiClientReturns(WeatherData weatherData)
        {
            FixtureElements.WeatherData = weatherData;
            FixtureElements.ApiClient.GetWheaterForCity(
                Arg.Is(FixtureElements.Query.City),
                Arg.Is(FixtureElements.Query.Country),
                Arg.Is(FixtureElements.Query.TemperatureScale)).Returns(weatherData);
            return this;
        }

        public GetWeatherQueryHandlerFixture ApiClientReturnsErrorResponse()
        {
            var response = new WeatherData();
            response.Status = "ERROR_STATUS";
            FixtureElements.ApiClient.GetWheaterForCity(
                Arg.Is(FixtureElements.Query.City),
                Arg.Is(FixtureElements.Query.Country),
                Arg.Is(FixtureElements.Query.TemperatureScale)).Returns(response);
            return this;
        }

        public GetWeatherQueryHandlerFixture NoCodeForQueriedCountryName()
        {
            FixtureElements.CountryCodesSource.SearchByName(Arg.Any<string>()).Returns(default(CountryCode));
            return this;
        }

        public GetWeatherQueryHandlerFixture SetCodeForQueriedCountry(string code)
        {
            FixtureElements.CountryCode = CountryCode.Create(FixtureElements.Query.Country, code);
            FixtureElements.CountryCodesSource.SearchByName(Arg.Is(FixtureElements.Query.Country))
                .Returns(FixtureElements.CountryCode);
            return this;
        }

        public GetWeatherQueryHandlerFixture Execute()
        {
            var sut = CreateSut();
            FixtureElements.Response = sut.ProcessAsync(FixtureElements.Query).Result;
            return this;
        }

        private IQueryHandler<GetWeatherDataQuery, SourceResponse<IWeatherInfo>> CreateSut()
        {
            var sut = new OpenWeatherMapQueryHandler(FixtureElements.ApiClient, FixtureElements.CountryCodesSource);
            return sut;
        }
    }
}