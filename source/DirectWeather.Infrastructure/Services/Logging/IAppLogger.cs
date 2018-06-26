namespace DirectWeather.Infrastructure.Services.Logging
{
    using System;

    public interface IAppLogger
    {
        void Debug(object message);

        void Debug(object message, Exception exception);

        void Warning(object message);

        void Warning(object message, Exception exception);

        void Info(object message);

        void Error(object message);

        void Error(object message, Exception exception);
    }
}