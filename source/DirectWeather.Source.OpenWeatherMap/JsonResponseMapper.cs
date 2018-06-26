namespace DirectWeather.Source.OpenWeatherMap
{
    using System.Globalization;

    using DirectWeather.Infrastructure.Mappers;
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class JsonResponseMapper : IStringMapper<WeatherData>
    {
        public WeatherData Map(string jsonData)
        {
            var weatherData = new WeatherData();
            var jData = JsonConvert.DeserializeObject<JObject>(jsonData);
            var responseCode = jData["cod"].ToString();
            weatherData.Status = responseCode;
            if (responseCode == "200")
            {
                var jWeatherData = jData["main"];
                weatherData.Humidity = decimal.Parse((string)jWeatherData["humidity"]);
                weatherData.Temperature = decimal.Parse((string)jWeatherData["temp"], CultureInfo.InvariantCulture);
                weatherData.DateTimestamp = long.Parse(jData["dt"].ToString());
                return weatherData;
            }

            weatherData.Message = jData["message"].ToString();

            return weatherData;
        }
    }
}