namespace DirectWeather.Source.OpenWeatherMap
{
    using System;

    using DirectWeather.Infrastructure.Dtos;

    public static class ApiExtensions
    {
        public static string ToText(this TemperatureScale temperatureScale)
        {
            switch (temperatureScale)
            {
                case TemperatureScale.Kelvin:
                    return "kelvin";
                case TemperatureScale.Celsius:
                    return "metric";
                case TemperatureScale.Fahrenheit:
                    return "imperial";
                default:
                    throw new ArgumentException(nameof(temperatureScale));
            }
        }
    }
}