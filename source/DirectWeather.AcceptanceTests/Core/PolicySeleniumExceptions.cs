namespace DirectWeather.AcceptanceTests.Core
{
    using System;

    using OpenQA.Selenium;

    using Polly;

    public static class PolicySeleniumExceptions
    {
        public static PolicyBuilder ForElements()
        {
            return Policy.Handle<NoSuchElementException>().Or<ElementNotVisibleException>()
                .Or<InvalidOperationException>().Or<StaleElementReferenceException>();
        }

        public static PolicyBuilder<TResult> ForElements<TResult>()
        {
            return Policy<TResult>.Handle<NoSuchElementException>().Or<ElementNotVisibleException>()
                .Or<InvalidOperationException>().Or<StaleElementReferenceException>();
        }
    }
}