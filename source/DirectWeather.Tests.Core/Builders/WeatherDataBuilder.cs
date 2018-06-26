namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public class WeatherDataBuilder : IBuild<WeatherData>
    {
        public long Timestamp { get; private set; } = 9001;

        public decimal Temperature { get; private set; } = 40;

        public TemperatureScale TemperatureScale { get; private set; } = TemperatureScale.Celsius;

        public string Message { get; private set; }

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

        public static implicit operator WeatherData(WeatherDataBuilder builder)
        {
            return builder.Build();
        }

        public WeatherData Build()
        {
            var data = new WeatherData();
            return data;
        }
    }
}