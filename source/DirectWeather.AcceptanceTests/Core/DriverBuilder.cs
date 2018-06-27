namespace DirectWeather.AcceptanceTests.Core
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.Events;

    public static class DriverBuilder
    {
        public static IWebDriver CreateDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            var chromeDriver = new ChromeDriver(service);

            var driver = new EventFiringWebDriver(chromeDriver);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}