namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
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

        [Fact]
        public void ensure_that_query_dispatcher_was_queried_with_proper_query()
        {
            getWeatherFixture
                .Accept(A.WeatherRequest().ForCity("Warsaw").InCountry("Poland"))
                .Execute()
                .AssertThat
                    .ValidWeatherQueryWasSendToQueryDispatcher();
        }

        [Fact]
        public void ensure_that_query_result_was_utilized_in_response_builder_mapping_method()
        {
            getWeatherFixture
                .Accept(A.WeatherRequest().ForCity("Warsaw").InCountry("Poland"))
                .AndTheResultForTheQueryIs(A.SuccessWeatherQueryResult())
                .Execute()
                .AssertThat
                    .ValidWeatherQueryWasSendResponseBuilder();
        }

        [Fact]
        public void ensure_that_action_returns_valid_response_from_response_builder()
        {
            getWeatherFixture
                .Accept(A.WeatherRequest().ForCity("Warsaw").InCountry("Poland"))
                .AndTheResultForTheQueryIs(A.SuccessWeatherQueryResult())
                .AndTheMappedResponseIs(A.ApiResponse().UseWeatherAsPayload(A.WeatherForWarsawInPoland()))
                .Execute()
                .AssertThat
                    .ReturnsValidApiResponse();
        }
    }
}