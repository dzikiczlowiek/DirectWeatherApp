namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Api.Models;

    public class WeatherRequestBuilder : IBuild<WeatherRequest>
    {
        public string Country { get; private set; }

        public string City { get; private set; }

        public WeatherRequestBuilder ForCity(string city)
        {
            City = city;
            return this;
        }

        public WeatherRequestBuilder InCountry(string country)
        {
            Country = country;
            return this;
        }

        public WeatherRequest Build()
        {
            var request = new WeatherRequest();
            request.City = City;
            request.Country = Country;
            return request;
        }

        public static implicit operator WeatherRequest(WeatherRequestBuilder builder)
        {
            return builder.Build();
        }
    }
}