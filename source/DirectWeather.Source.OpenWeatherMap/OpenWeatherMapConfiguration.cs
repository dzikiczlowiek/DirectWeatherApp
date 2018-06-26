namespace DirectWeather.Source.OpenWeatherMap
{
    using System.Configuration;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.Services.Http;

    public class OpenWeatherMapConfiguration : ConfigurationSection, IHttpClientApiConfiguration
    {
        public const string Name = "OpenWeatherMapConfiguration";

        [ConfigurationProperty("baseUrl", IsRequired = true)]
        public string BaseUrl
        {
            get => (string)this["baseUrl"];
            set => this["baseUrl"] = value;
        }

        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string ApiKey
        {
            get => (string)this["apiKey"];
            set => this["apiKey"] = value;
        }

        [ConfigurationProperty("temperatureScale", DefaultValue = TemperatureScale.Kelvin, IsRequired = false)]
        public TemperatureScale TemperatureScale
        {
            get => (TemperatureScale)this["temperatureScale"];
            set => this["temperatureScale"] = value;
        }
    }
}