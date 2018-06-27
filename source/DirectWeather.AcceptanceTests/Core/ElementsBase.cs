namespace DirectWeather.AcceptanceTests.Core
{
    using System.Collections.ObjectModel;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public abstract class ElementsBase : IPageElements
    {
        protected ElementsBase(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }

        protected IWebElement FindByTagName(string tagName) => FindBy(By.TagName(tagName));

        protected IWebElement FindByLinkText(string linkText) => FindBy(By.LinkText(linkText));

        protected IWebElement FindByPartialLinkText(string partialLinkText) =>
            FindBy(By.PartialLinkText(partialLinkText));

        protected IWebElement FindById(string id) => FindBy(By.Id(id));

        protected IWebElement FindByClass(string cssClass) => FindBy(By.ClassName(cssClass));

        protected IWebElement FindByCssSelector(string selector) => FindBy(By.CssSelector(selector));

        protected IWebElement FindByName(string name) => FindBy(By.Name(name));

        protected IWebElement FindByXPath(string xPath) => FindBy(By.XPath(xPath));

        protected IWebElement FindBy(By by) => SafeSearchContext.Wrap(Driver).FindElement(by);

        protected ReadOnlyCollection<IWebElement> FindMultipleByXpath(string xpath) => FindMultipleBy(By.XPath(xpath));

        protected ReadOnlyCollection<IWebElement> FindMultipleByCssSelector(string selector) =>
            FindMultipleBy(By.CssSelector(selector));

        protected ReadOnlyCollection<IWebElement> FindMultipleBy(By by) =>
            SafeSearchContext.Wrap(Driver).FindElements(by);

        protected void HoverAndClick(IWebElement element)
        {
            var mouseActions = new Actions(Driver);
            mouseActions.MoveToElement(element).Click().Build().Perform();
        }

        protected void RightClick(IWebElement element)
        {
            var mouseActions = new Actions(Driver);
            mouseActions.ContextClick(element).Build().Perform();
        }

        protected void SwitchToFrame(By by)
        {
            Driver.SwitchTo().Frame(Driver.FindElement(by));
        }

        protected void BackToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }
    }
}