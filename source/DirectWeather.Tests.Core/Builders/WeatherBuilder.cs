namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap;

    public class WeatherBuilder : IBuild<Weather>
    {
        public Temperature Temperature { get; } = new Temperature { Format = TemperatureScale.Celsius.ToText(), Value = 23 };

        public Location Location { get; } = new Location { Country = "Poland", City = "Warsaw" };

        public long DateTimestamp { get; } = 1934;

        public decimal Humidity { get; private set; } = 23;

        public static implicit operator Weather(WeatherBuilder builder)
        {
            return builder.Build();
        }

        public WeatherBuilder SetHumidity(decimal humidity)
        {
            Humidity = humidity;
            return this;
        }

        public WeatherBuilder SetTemperature(decimal temperature)
        {
            Temperature.Value = temperature;
            return this;
        }

        public WeatherBuilder InTemperatureScale(TemperatureScale temperatureScale)
        {
            Temperature.Format = temperatureScale.ToText();
            return this;
        }

        public WeatherBuilder ForCity(string city)
        {
            Location.City = city;
            return this;
        }

        public WeatherBuilder InCountry(string country)
        {
            Location.Country = country;
            return this;
        }

        public Weather Build()
        {
            var weather = new Weather();
            weather.Humidity = Humidity;
            weather.DateTimestamp = DateTimestamp;
            weather.Location = Location;
            weather.Temperature = Temperature;
            return weather;
        }
    }
}