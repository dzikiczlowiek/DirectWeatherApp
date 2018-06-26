namespace DirectWeather.Api.Models
{
    public class Weather
    {
        public long DateTimestamp { get; set; }

        public decimal Humidity { get; set; }

        public Location Location { get; set; }

        public Temperature Temperature { get; set; }
    }
}