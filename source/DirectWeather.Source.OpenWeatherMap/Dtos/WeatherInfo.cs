namespace DirectWeather.Source.OpenWeatherMap.Dtos
{
    using DirectWeather.Infrastructure.Dtos;

    internal class WeatherInfo : IWeatherInfo
    {
        public decimal Temperature { get; set; }

        public TemperatureScale TemperatureScale { get; set; }

        public decimal Humidity { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public long DateTimestamp { get; set; }
    }
}