namespace DirectWeather.AcceptanceTests.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;

    using OpenQA.Selenium;

    public class SafeWebElement : IWebElement
    {
        private readonly IWebElement webElement;

        private readonly IWebDriver driver;

        public SafeWebElement(IWebElement webElement, IWebDriver driver)
        {
            this.webElement = webElement;
            this.driver = driver;
        }

        public string TagName => webElement.TagName;

        public string Text => webElement.Text;

        public bool Enabled => webElement.Enabled;

        public bool Selected => webElement.Selected;

        public Point Location => webElement.Location;

        public Size Size => webElement.Size;

        public bool Displayed => webElement.Displayed;

        public static SafeWebElement Wrap(IWebElement webElement, IWebDriver driver)
        {
            return new SafeWebElement(webElement, driver);
        }
        public static SafeWebElement Wrap(Func<IWebElement> webElementGetter, IWebDriver driver)
        {
            var webElement = WebElementsPolicies.Current.Find.Execute(webElementGetter);

            return new SafeWebElement(webElement, driver);
        }

        public IWebElement FindElement(By by)
        {
            return Wrap(webElement.FindElement(by), driver);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var elements = Enumerable.Cast<IWebElement>(webElement.FindElements(@by).Select(e => Wrap(e, driver)))
                .ToList();
            return new ReadOnlyCollection<IWebElement>(elements);
        }

        public void Clear()
        {
            SafeExecution(() => webElement.Clear());
        }

        public void SendKeys(string text)
        {
            SafeExecution(() => webElement.SendKeys(text));
        }

        public void Submit()
        {
            SafeExecution(() => webElement.Submit());
        }

        public void Click()
        {
            SafeExecution(() => webElement.Click());
        }

        public string GetAttribute(string attributeName)
        {
            return SafeExecution(() => webElement.GetAttribute(attributeName));
        }

        public string GetProperty(string propertyName)
        {
            return SafeExecution(() => webElement.GetProperty(propertyName));
        }

        public string GetCssValue(string propertyName)
        {
            return SafeExecution(() => webElement.GetCssValue(propertyName));
        }

        private void SafeExecution(Action action)
        {
            WebElementsPolicies.Current.Action.Execute(action);
        }

        private T SafeExecution<T>(Func<T> action)
        {
            return WebElementsPolicies.Current.Action.Execute(action);
        }
    }
}