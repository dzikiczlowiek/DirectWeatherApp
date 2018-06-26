namespace DirectWeather.Infrastructure.Dtos
{
    public class QueryResult<TPayload> : QueryResult
    {
        public QueryResult(string message, ApiResponseStatus status)
            : base(message, status)
        {
        }

        public QueryResult(TPayload payload)
            : base(string.Empty, ApiResponseStatus.Ok)
        {
            Payload = payload;
        }

        public TPayload Payload { get; }

        public static QueryResult<TPayload> Success(TPayload payload) => new QueryResult<TPayload>(payload);

        public static QueryResult<TPayload> Error(string message) =>
            new QueryResult<TPayload>(message, ApiResponseStatus.Error);

        public static QueryResult<TPayload> NotFound(string message) =>
            new QueryResult<TPayload>(message, ApiResponseStatus.NotFound);
    }

    public class QueryResult
    {
        protected QueryResult(string message, ApiResponseStatus status)
        {
            Status = status;
            Message = message;
        }

        public string Message { get; protected set; }

        public ApiResponseStatus Status { get; protected set; }
    }
}