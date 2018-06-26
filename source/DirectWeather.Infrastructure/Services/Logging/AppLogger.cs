namespace DirectWeather.Infrastructure.Services.Logging
{
    using System;

    using log4net;

    public class AppLogger : IAppLogger
    {
        private readonly ILog log;

        public AppLogger(ILog log)
        {
            this.log = log;
        }

        public void Debug(object message)
        {
            log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }

        public void Error(object message)
        {
            log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public void Info(object message)
        {
            log.Info(message);
        }

        public void Warning(object message)
        {
            log.Warn(message);
        }

        public void Warning(object message, Exception exception)
        {
            log.Warn(message, exception);
        }
    }
}