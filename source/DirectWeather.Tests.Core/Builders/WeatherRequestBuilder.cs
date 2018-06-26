namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Api.Models;

    public class WeatherRequestBuilder : IBuild<WeatherRequest>
    {
        public WeatherRequest Build()
        {
            var request = new WeatherRequest();
            return request;
        }
    }
}
