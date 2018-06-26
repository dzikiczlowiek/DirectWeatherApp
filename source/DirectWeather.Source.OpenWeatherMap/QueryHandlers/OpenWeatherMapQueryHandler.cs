namespace DirectWeather.Source.OpenWeatherMap.QueryHandlers
{
    using System.Threading.Tasks;

    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.Extensions;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.Dtos;
    using DirectWeather.Source.OpenWeatherMap.Services;

    public class OpenWeatherMapQueryHandler : IQueryHandler<GetWeatherDataQuery, SourceResponse<IWeatherInfo>>
    {
        private readonly IOpenWeatherMapApiClient apiClient;

        private readonly ICountryCodesSource countryCodesSource;

        public OpenWeatherMapQueryHandler(IOpenWeatherMapApiClient apiClient, ICountryCodesSource countryCodesSource)
        {
            this.apiClient = apiClient;
            this.countryCodesSource = countryCodesSource;
        }

        public async Task<SourceResponse<IWeatherInfo>> ProcessAsync(GetWeatherDataQuery query)
        {
            var countryCode = countryCodesSource.SearchByName(query.Country);
            if (countryCode == null)
            {
                return SourceResponse<IWeatherInfo>.NotFound($"Could not find country '{query.Country}'");
            }

            var apiResponse = await apiClient.GetWheaterForCity(query.City, countryCode.Code, query.TemperatureScale);

            if (!apiResponse.IsResponseOk())
            {
                return SourceResponse<IWeatherInfo>.Error(apiResponse.Message);
            }

            var weatherInfo = new WeatherInfo();
            weatherInfo.City = query.City.ToTitleCase();
            weatherInfo.Country = countryCode.Name.ToTitleCase();
            weatherInfo.Humidity = apiResponse.Humidity;
            weatherInfo.Temperature = apiResponse.Temperature;
            weatherInfo.DateTimestamp = apiResponse.DateTimestamp;
            weatherInfo.TemperatureScale = query.TemperatureScale;
            return new SourceResponse<IWeatherInfo>(weatherInfo);
        }
    }
}