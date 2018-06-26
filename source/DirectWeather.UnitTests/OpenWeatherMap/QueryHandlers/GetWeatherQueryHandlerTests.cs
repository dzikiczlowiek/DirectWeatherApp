namespace DirectWeather.UnitTests.OpenWeatherMap.QueryHandlers
{
    using DirectWeather.Tests.Core;
    using DirectWeather.Tests.Core.Builders;

    using Xunit;

    public class GetWeatherQueryHandlerTests : TestsBase, IClassFixture<GetWeatherQueryHandlerFixture>
    {
        private readonly GetWeatherQueryHandlerFixture getWeatherQueryHandlerFixture;

        public GetWeatherQueryHandlerTests(GetWeatherQueryHandlerFixture getWeatherQueryHandlerFixture)
        {
            this.getWeatherQueryHandlerFixture = getWeatherQueryHandlerFixture;
        }

        [Fact]
        public void ensure_that_handler_returns_not_found_response_when_could_not_resolve_country_code()
        {
            getWeatherQueryHandlerFixture
                .For(A.WeatherQueryForWarsawInPoland().InCelsius())
                .NoCodeForQueriedCountryName()
                .Execute()
                    .AssertThat
                    .CountryCodeWasSearched()
                    .QueryDidNotFoundData();
        }

        [Fact]
        public void ensure_that_handler_returns_error_response_when_api_client_returns_invalid_response()
        {
            getWeatherQueryHandlerFixture
                .For(A.WeatherQueryForWarsawInPoland().InCelsius())
                .SetCodeForQueriedCountry("CO")
                .ApiClientReturnsErrorResponse()
                .Execute()
                .AssertThat
                    .ApiClientWasQueried()
                    .QueryReturnsError();
        }

        [Fact]
        public void ensure_that_handler_returns_valid_data()
        {
            getWeatherQueryHandlerFixture
                .For(A.WeatherQueryForWarsawInPoland().InCelsius())
                .SetCodeForQueriedCountry("CO")
                .ApiClientReturns(A.WeatherData().SuccessResponse())
                .Execute()
                .AssertThat
                    .ApiClientWasQueried()
                    .QueryReturnsSuccess();
        }
    }
}