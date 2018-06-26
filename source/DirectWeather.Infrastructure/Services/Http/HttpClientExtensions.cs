namespace DirectWeather.Infrastructure.Services.Http
{
    using System.Net.Http;

    public static class HttpClientExtensions
    {
        public static HttpMessageHandler DecorateWith(this HttpMessageHandler innerHandler, DelegatingHandler decorator)
        {
            decorator.InnerHandler = innerHandler;
            return decorator;
        }

        public static HttpMessageHandler DecorateWith(this DelegatingHandler innerHandler, DelegatingHandler decorator)
        {
            decorator.InnerHandler = innerHandler;
            return decorator;
        }
    }
}