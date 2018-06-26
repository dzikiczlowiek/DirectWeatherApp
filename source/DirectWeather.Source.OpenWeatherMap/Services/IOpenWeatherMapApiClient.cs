namespace DirectWeather.Source.OpenWeatherMap.Services
{
    using System.Threading.Tasks;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public interface IOpenWeatherMapApiClient
    {
        Task<WeatherData> GetWheaterForCity(string city, string countryCode, TemperatureScale? temperatureScale = null);
    }
}