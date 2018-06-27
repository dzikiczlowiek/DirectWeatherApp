namespace DirectWeather.AcceptanceTests.Core
{
    using System;

    using OpenQA.Selenium;

    using Polly.Retry;

    internal class WebElementsPolicies
    {
        private static readonly object SyncObject = new object();

        private static WebElementsPolicies current;

        private WebElementsPolicies()
        {
            if (current != null)
            {
                throw new InvalidOperationException($"Only one instance of {typeof(WebElementsPolicies).Name} allowed.");
            }

            Find = PolicySeleniumExceptions.ForElements<IWebElement>().TestRetryBehavior();

            Action = PolicySeleniumExceptions.ForElements().TestRetryBehavior();
        }

        public static WebElementsPolicies Current
        {
            get
            {
                lock (SyncObject)
                {
                    return current ?? (current = new WebElementsPolicies());
                }
            }
        }

        public RetryPolicy<IWebElement> Find { get; }

        public RetryPolicy Action { get; }
    }
}
