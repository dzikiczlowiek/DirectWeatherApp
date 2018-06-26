namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public class WeatherDataBuilder : IBuild<WeatherData>
    {
        public long Timestamp { get; private set; } = 9001;

        public decimal Temperature { get; private set; } = 40;

        public decimal Humidity { get; private set; } = 23;

        public TemperatureScale TemperatureScale { get; private set; } = TemperatureScale.Celsius;

        public string Message { get; private set; }

        public string Status { get; private set; }

        public static implicit operator WeatherData(WeatherDataBuilder builder)
        {
            return builder.Build();
        }

        public WeatherDataBuilder SuccessResponse()
        {
            Status = "200";
            return this;
        }

        public WeatherDataBuilder CreatedAt(long timestamp)
        {
            Timestamp = timestamp;
            return this;
        }

        public WeatherDataBuilder WithTemperature(decimal temperature)
        {
            Temperature = temperature;
            return this;
        }

        public WeatherDataBuilder WithHumidity(decimal humidity)
        {
            Humidity = humidity;
            return this;
        }

        public WeatherDataBuilder InTemperatureScale(TemperatureScale temperatureScale)
        {
            TemperatureScale = temperatureScale;
            return this;
        }

        public WeatherDataBuilder WithMessage(string message)
        {
            Message = message;
            return this;
        }

        public WeatherDataBuilder InCelsiuses() => InTemperatureScale(TemperatureScale.Celsius);

        public WeatherDataBuilder InKelvins() => InTemperatureScale(TemperatureScale.Kelvin);

        public WeatherDataBuilder InFahrenheits() => InTemperatureScale(TemperatureScale.Fahrenheit);

        public WeatherData Build()
        {
            var data = new WeatherData();
            data.Message = Message;
            data.DateTimestamp = Timestamp;
            data.Humidity = Humidity;
            data.Status = Status;
            return data;
        }
    }
}