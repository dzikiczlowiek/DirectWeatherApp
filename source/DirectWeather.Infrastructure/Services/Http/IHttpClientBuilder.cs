namespace DirectWeather.Infrastructure.Services.Http
{
    using System.Net.Http;

    public interface IHttpClientBuilder
    {
        HttpClient Build();
    }
}