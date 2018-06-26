namespace DirectWeather.Source.OpenWeatherMap.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.Mappers;
    using DirectWeather.Infrastructure.Services.Http;
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public class OpenWeatherMapApiClient : IOpenWeatherMapApiClient
    {
        private readonly HttpClient httpClient;

        private readonly IStringMapper<WeatherData> jsonResponseMapper;

        private readonly IHttpClientApiConfiguration apiConfiguration;

        public OpenWeatherMapApiClient(
            HttpClient httpClient,
            IStringMapper<WeatherData> jsonResponseMapper,
            IHttpClientApiConfiguration apiConfiguration)
        {
            this.httpClient = httpClient;
            this.jsonResponseMapper = jsonResponseMapper;
            this.apiConfiguration = apiConfiguration;
        }

        public async Task<WeatherData> GetWheaterForCity(
            string city,
            string countryCode,
            TemperatureScale? temperatureScale = null)
        {
            var url =
                $"data/2.5/weather?q={city},{countryCode}&units={(temperatureScale ?? apiConfiguration.TemperatureScale).ToText()}&type=like&APPID={apiConfiguration.ApiKey}";
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode || response.Content.Headers.ContentType.MediaType != "application/json")
            {
                response.Content?.Dispose();
            }

            return jsonResponseMapper.Map(responseContent);
        }
    }
}