namespace DirectWeather.Source.OpenWeatherMap.Services
{
    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public interface ICountryCodesSource
    {
        CountryCode SearchByName(string term);
    }
}