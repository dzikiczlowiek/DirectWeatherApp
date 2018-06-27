namespace DirectWeather.AcceptanceTests.Core
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using OpenQA.Selenium;

    public class SafeSearchContext : ISearchContext
    {
        private readonly IWebDriver driver;

        public SafeSearchContext(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static SafeSearchContext Wrap(IWebDriver driver) => new SafeSearchContext(driver);

        public IWebElement FindElement(By @by) =>
            WebElementsPolicies.Current.Find.Execute(() => SafeWebElement.Wrap(driver.FindElement(@by), driver));

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            var elements = Enumerable
                .Cast<IWebElement>(driver.FindElements(@by).Select(e => SafeWebElement.Wrap(e, driver))).ToList();
            return new ReadOnlyCollection<IWebElement>(elements);
        }
    }
}