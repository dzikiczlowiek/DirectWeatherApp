namespace DirectWeather.Api.Models
{
    using System.Web.Http;

    using DirectWeather.Api.ActionResults;
    using DirectWeather.Infrastructure.Dtos;

    using NodaTime;

    public class ResponseBuilder : IResponseBuilder
    {
        private readonly IClock clock;

        public ResponseBuilder(IClock clock)
        {
            this.clock = clock;
        }

        public IHttpActionResult MapWeatherDataResponse(QueryResult<IWeatherInfo> queryResult)
        {
            var timestamp = clock.GetCurrentInstant().ToUnixTimeSeconds();
            switch (queryResult.Status)
            {
                case ApiResponseStatus.Ok:
                    {
                        var weather = new Weather();
                        weather.DateTimestamp = queryResult.Payload.DateTimestamp;
                        weather.Humidity = queryResult.Payload.Humidity;

                        var location = new Location();
                        location.City = queryResult.Payload.City;
                        location.Country = queryResult.Payload.Country;
                        weather.Location = location;

                        var temperature = new Temperature();
                        temperature.Value = queryResult.Payload.Temperature;
                        temperature.Format = queryResult.Payload.TemperatureScale.ToString();
                        weather.Temperature = temperature;

                        return ApiResponse<Weather>.Success(weather, timestamp);
                    }

                default:
                    return ApiResponse.Error(queryResult.Message, timestamp);
            }
        }
    }
}