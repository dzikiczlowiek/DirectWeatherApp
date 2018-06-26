namespace DirectWeather.Tests.Core.Builders
{
    using System.Globalization;

    public class JsonWeatherResponseBuilder : IBuild<string>
    {
        private string template;

        public string Status { get; private set; } = "200";

        public decimal Humidity { get; private set; } = 0m;

        public decimal Temperature { get; private set; } = 0m;

        public string Message { get; private set; }

        public long Timestamp { get; private set; } = 0;

        public static JsonWeatherResponseBuilder Success()
        {
            return new JsonWeatherResponseBuilder().Succes();
        }

        public static JsonWeatherResponseBuilder Error(string message)
        {
            return new JsonWeatherResponseBuilder().StatusData(400, message);
        }

        public static JsonWeatherResponseBuilder NotFound(string message)
        {
            return new JsonWeatherResponseBuilder().StatusData(404, message);
        }

        public static implicit operator string(JsonWeatherResponseBuilder builder)
        {
            return builder.Build();
        }

        public JsonWeatherResponseBuilder Succes()
        {
            template = TestData.ValidSuccessJsonData;
            Status = "200";
            return this;
        }

        public JsonWeatherResponseBuilder StatusData(int errorStatus, string message)
        {
            template = TestData.ValidErrorJsonData;
            Status = errorStatus.ToString();
            Message = message;
            return this;
        }

        public JsonWeatherResponseBuilder SetTemperatureTo(decimal temp)
        {
            Temperature = temp;
            return this;
        }

        public JsonWeatherResponseBuilder SetHumidityTo(decimal humidity)
        {
            Humidity = humidity;
            return this;
        }

        public JsonWeatherResponseBuilder SetTimestamp(int timestamp)
        {
            Timestamp = timestamp;
            return this;
        }

        public string Build()
        {
            var json = template
                .Replace(Variables.TemperatureMarker, Temperature.ToString(CultureInfo.InvariantCulture))
                .Replace(Variables.HumidityMarker, Humidity.ToString(CultureInfo.InvariantCulture))
                .Replace(Variables.CodMarker, Status)
                .Replace(Variables.MessageMarker, Message)
                .Replace(Variables.TimestampMarker, Timestamp.ToString());

            return json;
        }

        private static class Variables
        {
            public const string TemperatureMarker = "<TEMP_VARIABLE>";

            public const string HumidityMarker = "<HUMIDITY_VARIABLE>";

            public const string CodMarker = "<COD_VARIABLE>";

            public const string MessageMarker = "<MESSAGE_VARIABLE>";

            public const string TimestampMarker = "<TIMESTAMP_VARIABLE>";
        }
    }
}