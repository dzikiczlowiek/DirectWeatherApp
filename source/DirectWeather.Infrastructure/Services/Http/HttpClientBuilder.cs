namespace DirectWeather.Infrastructure.Services.Http
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using DirectWeather.Infrastructure.Services.Logging;

    public class HttpClientBuilder : IHttpClientBuilder
    {
        private readonly IHttpClientApiConfiguration configuration;

        private readonly IAppLogger appLogger;

        public HttpClientBuilder(IHttpClientApiConfiguration configuration, IAppLogger appLogger)
        {
            this.configuration = configuration;
            this.appLogger = appLogger;
        }

        public HttpClient Build()
        {
            var pipeline = new HttpClientHandler().DecorateWith(new ResilencyHandler(appLogger))
                .DecorateWith(new LoggingHandler(appLogger));

            var endpoint = new Uri(configuration.BaseUrl);
            var httpClient = new HttpClient(pipeline) { BaseAddress = endpoint };
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;
            ServicePointManager.FindServicePoint(endpoint).ConnectionLeaseTimeout =
                (int)TimeSpan.FromMinutes(2).TotalMilliseconds;
            ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}