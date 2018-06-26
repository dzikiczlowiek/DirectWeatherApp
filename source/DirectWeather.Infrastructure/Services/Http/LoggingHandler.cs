namespace DirectWeather.Infrastructure.Services.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using DirectWeather.Infrastructure.Services.Logging;

    public class LoggingHandler : DelegatingHandler
    {
        private readonly IAppLogger appLogger;

        public LoggingHandler(IAppLogger appLogger)
        {
            this.appLogger = appLogger;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            appLogger.Debug(request);
            try
            {
                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                ex.Data["Request"] = request;
                appLogger.Error("SendAsync Error", ex);
                throw;
            }
        }
    }
}