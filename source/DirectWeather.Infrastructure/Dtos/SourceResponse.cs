namespace DirectWeather.Infrastructure.Dtos
{
    public class SourceResponse
    {
        protected SourceResponse(string message, SourceResponseStatus status)
        {
            Status = status;
            Message = message;
        }

        public string Message { get; protected set; }

        public SourceResponseStatus Status { get; protected set; }
    }

    public class SourceResponse<TPayload> : SourceResponse
    {
        public SourceResponse(string message, SourceResponseStatus status)
            : base(message, status)
        {
        }

        public SourceResponse(TPayload payload)
            : base(string.Empty, SourceResponseStatus.Ok)
        {
            Payload = payload;
        }

        public TPayload Payload { get; }

        public static SourceResponse<TPayload> Success(TPayload payload) => new SourceResponse<TPayload>(payload);

        public static SourceResponse<TPayload> Error(string message) =>
            new SourceResponse<TPayload>(message, SourceResponseStatus.Failure);

        public static SourceResponse<TPayload> NotFound(string message) =>
            new SourceResponse<TPayload>(message, SourceResponseStatus.NotFound);
    }

    public enum SourceResponseStatus
    {
        Unknown = 0,

        Ok = 1,

        NotFound = 2,

        Failure = 3
    }
}