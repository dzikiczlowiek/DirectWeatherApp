namespace DirectWeather.Source.OpenWeatherMap.QueryHandlers
{
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.QueryHandlers;

    public class GetWeatherDataQuery : IQuery<QueryResult<IWeatherInfo>>
    {
        private GetWeatherDataQuery(string country, string city, TemperatureScale temperatureScale)
        {
            TemperatureScale = temperatureScale;
            City = city;
            Country = country;
        }

        public string Country { get; }

        public string City { get; }

        public TemperatureScale TemperatureScale { get; }

        public static GetWeatherDataQuery Create(string country, string city, TemperatureScale temperatureScale) =>
            new GetWeatherDataQuery(country, city, temperatureScale);
    }
}