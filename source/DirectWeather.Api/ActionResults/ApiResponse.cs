namespace DirectWeather.Api.ActionResults
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DirectWeather.Api.Models;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    public class ApiResponse : IHttpActionResult
    {
        public ApiResponse(string message, ResponseStatus status, long timestamp)
        {
            Status = status;
            Message = message;
            Timestamp = timestamp;
        }

        public long Timestamp { get; set; }

        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseStatus Status { get; set; }

        public static ApiResponse Error(string message, long timestamp) =>
            new ApiResponse(message, ResponseStatus.Failure, timestamp);

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatter.UseDataContractJsonSerializer = false;
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ObjectContent(typeof(ApiResponse), this, formatter, "application/json");

            return Task.FromResult(response);
        }
    }

    public class ApiResponse<TPayload> : ApiResponse
    {
        public ApiResponse(TPayload payload, long timestamp)
            : base(string.Empty, ResponseStatus.Ok, timestamp)
        {
            Payload = payload;
        }

        public TPayload Payload { get; }

        public static ApiResponse<TPayload> Success(TPayload payload, long timestamp) =>
            new ApiResponse<TPayload>(payload, timestamp);
    }
}