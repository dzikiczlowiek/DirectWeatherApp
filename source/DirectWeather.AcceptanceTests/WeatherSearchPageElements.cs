namespace DirectWeather.AcceptanceTests
{
    using DirectWeather.AcceptanceTests.Core;

    using OpenQA.Selenium;

    public class WeatherSearchPageElements : ElementsBase
    {
        public WeatherSearchPageElements(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement CountryElement => FindById("country");

        public IWebElement CityElement => FindById("city");

        public IWebElement SearchButton => FindById("searchBtn");

        public IWebElement Location => FindById("location");

        public IWebElement Humidity => FindById("humidityValue");

        public IWebElement Temperature => FindById("temperature");

        public string Country
        {
            set => CountryElement.SendKeys(value);
        }

        public string City
        {
            set => CityElement.SendKeys(value);
        }
    }
}