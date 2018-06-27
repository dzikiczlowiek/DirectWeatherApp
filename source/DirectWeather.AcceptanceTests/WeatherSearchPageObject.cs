namespace DirectWeather.AcceptanceTests
{
    using DirectWeather.AcceptanceTests.Core;

    using OpenQA.Selenium;

    public class WeatherSearchPageObject : PageObject<WeatherSearchPageElements>
    {
        public WeatherSearchPageObject(IWebDriver driver, string url)
            : base(driver, new WeatherSearchPageElements(driver))
        {
            Url = url;
        }

        protected string Url { get; }

        public WeatherSearchPageObject NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public WeatherSearchPageObject TypeCity(string city)
        {
            Map.City = city;
            return this;
        }

        public WeatherSearchPageObject TypeCountry(string country)
        {
            Map.Country = country;
            return this;
        }

        public WeatherSearchPageObject Search()
        {
            Map.SearchButton.Click();
            return this;
        }
    }
}