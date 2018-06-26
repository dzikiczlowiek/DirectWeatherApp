namespace DirectWeather.Tests.Core.Builders
{
    using DirectWeather.Infrastructure.Dtos;

    public static class DataGeneratorHookExtensions
    {
        public static JsonWeatherResponseBuilder WeatherJsonData(this DataGeneratorHook hook)
        {
            return JsonWeatherResponseBuilder.Success();
        }

        public static JsonWeatherResponseBuilder ErrorJsonData(this DataGeneratorHook hook, string message)
        {
            return JsonWeatherResponseBuilder.Error(message);
        }

        public static JsonWeatherResponseBuilder NotFoundJsonData(this DataGeneratorHook hook, string message)
        {
            return JsonWeatherResponseBuilder.NotFound(message);
        }

        public static GetWeatherDataQueryBuilder WeatherQuery(this DataGeneratorHook hook)
        {
            return new GetWeatherDataQueryBuilder();
        }

        public static GetWeatherDataQueryBuilder WeatherQueryForWarsawInPoland(this DataGeneratorHook hook)
        {
            return new GetWeatherDataQueryBuilder().ForCity("Warsaw").ForCountry("Poland");
        }

        public static ApiResonseBuilder ApiResponse(this DataGeneratorHook hook)
        {
            return new ApiResonseBuilder();
        }

        public static WeatherBuilder WeatherForWarsawInPoland(this DataGeneratorHook hook)
        {
            return new WeatherBuilder().SetTemperature(23).InTemperatureScale(TemperatureScale.Celsius)
                .InCountry("Poland").ForCity("Warsaw").SetHumidity(40);
        }

        public static WeatherRequestBuilder WeatherRequest(this DataGeneratorHook hook)
        {
            return new WeatherRequestBuilder();
        }

        public static WeatherDataBuilder WeatherData(this DataGeneratorHook hook)
        {
            return new WeatherDataBuilder();
        }

        // TODO: move somewhere else
        public static QueryResult<IWeatherInfo> SuccessWeatherQueryResult(this DataGeneratorHook hook)
        {
            return QueryResult<IWeatherInfo>.Success(default(IWeatherInfo));
        }
    }
}