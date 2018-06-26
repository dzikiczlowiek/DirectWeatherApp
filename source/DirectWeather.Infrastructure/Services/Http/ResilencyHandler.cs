namespace DirectWeather.Infrastructure.Services.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DirectWeather.Infrastructure.Services.Logging;

    using Polly;
    using Polly.Retry;

    public class ResilencyHandler : DelegatingHandler
    {
        private readonly IAppLogger appLogger;

        public ResilencyHandler(IAppLogger appLogger)
        {
            this.appLogger = appLogger;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var sendPolicy = CreatePolicy();
            return sendPolicy.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
        }

        private RetryPolicy CreatePolicy()
        {
            return Policy.Handle<HttpRequestException>().WaitAndRetryAsync(
                6,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                    {
                        var msg = $"Retry {retryCount} implemented with Pollys RetryPolicy "
                                  + $"of {context.PolicyKey} " + $"at {context.CorrelationId}, "
                                  + $"due to: {exception}.";
                        appLogger.Warning(msg, exception);
                    });
        }
    }
}