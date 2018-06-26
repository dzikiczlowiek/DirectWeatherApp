namespace DirectWeather.Source.OpenWeatherMap.Dtos
{
    public class WeatherData
    {
        public long DateTimestamp { get; set; }

        public decimal Temperature { get; set; }

        public decimal Humidity { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }

    public static class WeatherDataExtensions
    {
        public static bool IsResponseOk(this WeatherData data)
        {
            return data.Status == "200";
        }
    }
}