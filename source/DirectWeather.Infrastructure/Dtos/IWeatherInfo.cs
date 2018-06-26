namespace DirectWeather.Infrastructure.Dtos
{
    public interface IWeatherInfo
    {
        long DateTimestamp { get; }

        decimal Temperature { get; }

        TemperatureScale TemperatureScale { get; }

        decimal Humidity { get; }

        string City { get; }

        string Country { get; }
    }
}