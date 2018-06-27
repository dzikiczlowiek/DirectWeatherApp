namespace DirectWeather.AcceptanceTests
{
    using OpenQA.Selenium;

    public abstract class PageObject<TMap> : IPage
        where TMap : ElementsBase
    {
        protected PageObject(IWebDriver driver, TMap map)
        {
            Map = map;
            Driver = driver;
        }

        public TMap Map { get; }

        protected IWebDriver Driver { get; set; }
    }
}