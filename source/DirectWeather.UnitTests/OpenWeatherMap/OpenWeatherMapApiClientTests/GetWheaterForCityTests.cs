namespace DirectWeather.UnitTests.OpenWeatherMap.OpenWeatherMapApiClientTests
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Tests.Core;

    using Xunit;

    public class GetWheaterForCityTests : TestsBase, IClassFixture<GetWheaterForCityFixture>
    {
        private readonly GetWheaterForCityFixture fixture;

        public GetWheaterForCityTests(GetWheaterForCityFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void ensure_that_request_parameter_is_properly_project_to_http_get_url()
        {
            fixture.ForCity("Warsaw").WithCountryCode("PL").ResultIn(TemperatureScale.Celsius)
                .ApiReponseMappedToDefaultValue().Execute().AssertThat
                .ApiGetUrlIsProperlyGeneratedUsingWeatherRequest();
        }

        [Fact]
        public void ensure_that_http_response_goes_through_json_mapper()
        {
            fixture.ForCity("Warsaw").WithCountryCode("PL").ResultIn(TemperatureScale.Celsius)
                .ApiReponseMappedToDefaultValue().Execute().AssertThat.HttpResponseGoesThroughMapper();
        }
    }
}