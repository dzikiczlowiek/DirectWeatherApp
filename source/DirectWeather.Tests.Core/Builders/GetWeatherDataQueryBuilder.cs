namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;

    public class GetWeatherDataQueryBuilder : IBuild<GetWeatherDataQuery>
    {
        public string City { get; private set; }

        public string Country { get; private set; }

        public TemperatureScale TemperatureScale { get; private set; }

        public static implicit operator GetWeatherDataQuery(GetWeatherDataQueryBuilder builder)
        {
            return builder.Build();
        }

        public GetWeatherDataQueryBuilder ForCity(string city)
        {
            City = city;
            return this;
        }

        public GetWeatherDataQueryBuilder ForCountry(string country)
        {
            Country = country;
            return this;
        }

        public GetWeatherDataQueryBuilder TemperatureIn(TemperatureScale temperatureScale)
        {
            TemperatureScale = temperatureScale;
            return this;
        }

        public GetWeatherDataQueryBuilder InCelsius()
        {
            return TemperatureIn(TemperatureScale.Celsius);
        }

        public GetWeatherDataQueryBuilder InFahrenheit()
        {
            return TemperatureIn(TemperatureScale.Fahrenheit);
        }

        public GetWeatherDataQueryBuilder InKelvin()
        {
            return TemperatureIn(TemperatureScale.Kelvin);
        }

        public GetWeatherDataQuery Build()
        {
            return GetWeatherDataQuery.Create(Country, City, TemperatureScale);
        }
    }
}