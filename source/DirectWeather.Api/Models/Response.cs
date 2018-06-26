namespace DirectWeather.Api.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Response
    {
        protected Response(string message, ResponseStatus status, long timestamp)
        {
            Status = status;
            Message = message;
            Timestamp = timestamp;
        }

        public long Timestamp { get; set; }

        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseStatus Status { get; set; }

        public static Response Error(string message, long timestamp) =>
            new Response(message, ResponseStatus.Failure, timestamp);
    }

    public class Response<TPayload> : Response
    {
        public Response(TPayload payload, long timestamp)
            : base(string.Empty, ResponseStatus.Ok, timestamp)
        {
            Payload = payload;
        }

        public TPayload Payload { get; }

        public static Response<TPayload> Success(TPayload payload, long timestamp) =>
            new Response<TPayload>(payload, timestamp);
    }
}