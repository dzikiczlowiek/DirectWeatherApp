namespace DirectWeather.AcceptanceTests.Core
{
    using System;

    using Polly;
    using Polly.Retry;

    public static class RetryBehaviorExtensions
    {
        public static RetryPolicy TestRetryBehavior(this PolicyBuilder policy)
        {
            return policy.WaitAndRetry(60, retry => TimeSpan.FromSeconds(1));
        }

        public static RetryPolicy<TResult> TestRetryBehavior<TResult>(this PolicyBuilder<TResult> policy)
        {
            return policy.WaitAndRetry(60, retry => TimeSpan.FromSeconds(1));
        }
    }
}