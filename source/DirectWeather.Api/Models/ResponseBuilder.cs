namespace DirectWeather.Api.Models
{
    using DirectWeather.Infrastructure.Dtos;

    using NodaTime;

    public class ResponseBuilder
    {
        private readonly IClock clock;

        public ResponseBuilder(IClock clock)
        {
            this.clock = clock;
        }

        public dynamic MapWeatherDataResponse(SourceResponse<IWeatherInfo> sourceResponse)
        {
            var timestamp = clock.GetCurrentInstant().ToUnixTimeSeconds();
            switch (sourceResponse.Status)
            {
                case SourceResponseStatus.Ok:
                    {
                        var weather = new Weather();
                        weather.DateTimestamp = sourceResponse.Payload.DateTimestamp;
                        weather.Humidity = sourceResponse.Payload.Humidity;

                        var location = new Location();
                        location.City = sourceResponse.Payload.City;
                        location.Country = sourceResponse.Payload.Country;
                        weather.Location = location;

                        var temperature = new Temperature();
                        temperature.Value = sourceResponse.Payload.Temperature;
                        temperature.Format = sourceResponse.Payload.TemperatureScale.ToString();
                        weather.Temperature = temperature;

                        return Response<Weather>.Success(weather, timestamp);
                    }

                default:
                    return Response.Error(sourceResponse.Message, timestamp);
            }
        }
    }
}