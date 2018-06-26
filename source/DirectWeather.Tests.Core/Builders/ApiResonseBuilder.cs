namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Api.ActionResults;
    using DirectWeather.Api.Models;

    public class ApiResonseBuilder : IBuild<ApiResponse>, IBuild<ApiResponse<Weather>>
    {
        public Weather Weather { get; private set; }

        public long Timestamp { get; private set; } = 9001;

        public string Message { get; private set; }

        public ResponseStatus Status { get; private set; }


        public static implicit operator ApiResponse(ApiResonseBuilder builder)
        {
            return ((IBuild<ApiResponse>)builder).Build();
        }

        public static implicit operator ApiResponse<Weather>(ApiResonseBuilder builder)
        {
            return ((IBuild<ApiResponse<Weather>>)builder).Build();
        }

        public ApiResonseBuilder SetMessage(string message)
        {
            Message = message;
            return this;
        }

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
}