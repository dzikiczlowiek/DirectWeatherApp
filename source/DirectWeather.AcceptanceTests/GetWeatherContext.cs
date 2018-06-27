namespace DirectWeather.AcceptanceTests
{
    using System.Threading;

    using DirectWeather.AcceptanceTests.Configuration;
    using DirectWeather.AcceptanceTests.Core;

    using FluentAssertions;

    using OpenQA.Selenium;

    public class GetWeatherContext
    {
        public GetWeatherContext()
        {
            Driver = DriverBuilder.CreateDriver();
            WeatherSearchPage = new WeatherSearchPageObject(Driver, TestsConfiguration.Url);
        }

        public string Country { get; set; }

        public string City { get; set; }

        public WeatherSearchPageObject WeatherSearchPage { get; }

        protected IWebDriver Driver { get; }

        public void given_a_webpage_with_a_form()
        {
            WeatherSearchPage.NavigateTo();
        }

        public void and_I_type_city(string city)
        {
            City = city.Trim();
            WeatherSearchPage.TypeCity(city);
        }

        public void and_I_type_country(string country)
        {
            Country = country.Trim();
            WeatherSearchPage.TypeCountry(country);
        }

        public void when_I_submit_the_form()
        {
            WeatherSearchPage.Search();
        }

        public void then_I_receive_the_temperature_and_humidity_conditions_on_the_day_for_queried_location()
        {
            WeatherSearchPage.Map.Temperature.Text.Should().NotBeNullOrEmpty();
            WeatherSearchPage.Map.Temperature.Text.Should().Contain("Celsius");
            WeatherSearchPage.Map.Location.Text.Trim().ToLower().Should().StartWith(City.ToLower());
            WeatherSearchPage.Map.Location.Text.Trim().ToLower().Should().EndWith(Country.ToLower());
            WeatherSearchPage.Map.Humidity.Text.Trim().Should().NotBeNullOrEmpty();
        }

        public void close_browser()
        {
            Thread.Sleep(1000);
            Driver.Quit();
        }
    }
}