namespace DirectWeather.Tests.Core.Builders
{
    using System.Globalization;

    public class JsonWeatherResponseBuilder : IBuild<string>
    {
        private JsonWeatherResponseBuilder()
        {
        }

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
            var json = template.Replace(TemperatureMarker, Temperature.ToString(CultureInfo.InvariantCulture))
                .Replace(HumidityMarker, Humidity.ToString(CultureInfo.InvariantCulture)).Replace(CodMarker, Status)
                .Replace(MessageMarker, Message).Replace(TimestampMarker, Timestamp.ToString());

            return json;
        }

        public static implicit operator string(JsonWeatherResponseBuilder builder)
        {
            return builder.Build();
        }

        private const string TemperatureMarker = "<TEMP_VARIABLE>";

        private const string HumidityMarker = "<HUMIDITY_VARIABLE>";

        private const string CodMarker = "<COD_VARIABLE>";

        private const string MessageMarker = "<MESSAGE_VARIABLE>";

        private const string TimestampMarker = "<TIMESTAMP_VARIABLE>";

        private string template;

        public string Status { get; private set; } = "200";

        public decimal Humidity { get; private set; } = 0m;

        public decimal Temperature { get; private set; } = 0m;

        public string Message { get; private set; }

        public long Timestamp { get; private set; } = 0;
    }
}