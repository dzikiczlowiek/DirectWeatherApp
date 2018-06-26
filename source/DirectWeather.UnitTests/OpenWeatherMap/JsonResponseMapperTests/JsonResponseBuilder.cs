namespace DirectWeather.UnitTests.WeatherSource.OpenWeatherMap.JsonResponseMapperTests
{
    using DirectWeather.UnitTests.Core;

    public class JsonWeatherResponseBuilder : IBuild<string>
    {
        public JsonWeatherResponseBuilder Succes()
        {
            status = "200";
            return this;
        }

        public string Build()
        {
            var json = TestData.ValidJsonData.Replace(TemperatureMarker, temperature).Replace(HumidityMarker, humidity)
                .Replace(CodMarker, status);

            return json;
        }

        private const string TemperatureMarker = "<TEMP_VARIABLE>";

        private const string HumidityMarker = "<HUMIDITY_VARIABLE>";

        private const string CodMarker = "<COD_VARIABLE>";

        private string temperature = "0";

        private string humidity = "0";

        private string status = "200";
    }
}