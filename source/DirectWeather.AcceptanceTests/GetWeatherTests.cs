namespace DirectWeather.AcceptanceTests
{
    using LightBDD.Framework.Scenarios.Contextual;
    using LightBDD.Framework.Scenarios.Extended;
    using LightBDD.XUnit2;

    using Xunit;


    public class GetWeatherTests : FeatureFixture
    {
        [Scenario(DisplayName = "Local weather in a given city")]
        [InlineData("Warsaw", "Poland")]
        [InlineData("Gdansk", "Poland")]
        [InlineData("Berlin", "Germany")]
        public void check_weather_for_specific_locations(string city, string country)
        {
            Runner
                .WithContext<GetWeatherContext>()
                .RunScenario(
                _ => _.given_a_webpage_with_a_form(),
                _ => _.and_I_type_city(city),
                _ => _.and_I_type_country(country),
                _ => _.when_I_submit_the_form(),
                _ => _.then_I_receive_the_temperature_and_humidity_conditions_on_the_day_for_queried_location(),
                _ => _.close_browser());
        }

    }
}
