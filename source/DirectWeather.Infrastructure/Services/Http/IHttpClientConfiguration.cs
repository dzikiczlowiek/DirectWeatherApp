namespace DirectWeather.Infrastructure.Services.Http
{
    using DirectWeather.Infrastructure.Dtos;

    public interface IHttpClientApiConfiguration
    {
        string BaseUrl { get; }

        string ApiKey { get; }

        TemperatureScale TemperatureScale { get; }
    }
}