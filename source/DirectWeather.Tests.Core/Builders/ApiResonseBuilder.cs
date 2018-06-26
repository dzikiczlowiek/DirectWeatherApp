namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Api.ActionResults;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap;

    public class ApiResonseBuilder : IBuild<ApiResponse>, IBuild<ApiResponse<Weather>>
    {
        public Weather Weather { get; private set; }

        public long Timestamp { get; private set; } = 9001;

        public ApiResonseBuilder SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public string Message { get; set; }

        public ResponseStatus Status { get; set; }

        public ApiResonseBuilder SetResponseTimestamp(long timestamp)
        {
            Timestamp = timestamp;
            return this;
        }

        public ApiResonseBuilder UseWeatherAsPayload(Weather weather)
        {
            Weather = weather;
            return this;
        }

        public ApiResonseBuilder SetStatus(ResponseStatus status)
        {
            Status = status;
            return this;
        }

        public static implicit operator ApiResponse(ApiResonseBuilder builder)
        {
            return ((IBuild<ApiResponse>)builder).Build();
        }

        public static implicit operator ApiResponse<Weather>(ApiResonseBuilder builder)
        {
            return ((IBuild<ApiResponse<Weather>>)builder).Build();
        }

        ApiResponse<Weather> IBuild<ApiResponse<Weather>>.Build()
        {
            var response = new ApiResponse<Weather>(Weather, Timestamp);
            return response;
        }

        ApiResponse IBuild<ApiResponse>.Build()
        {
            var response = new ApiResponse(Message, Status, Timestamp);
            return response;
        }
    }

    public class WeatherBuilder : IBuild<Weather>
    {
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

        public static implicit operator Weather(WeatherBuilder builder)
        {
            return builder.Build();
        }

        public Temperature Temperature { get; set; } =
            new Temperature { Format = TemperatureScale.Celsius.ToText(), Value = 23 };

        public Location Location { get; set; } = new Location { Country = "Poland", City = "Warsaw" };

        public long DateTimestamp { get; set; } = 1934;

        public decimal Humidity { get; set; } = 23;
    }
}