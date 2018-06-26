namespace DirectWeather.Source.OpenWeatherMap.Dtos
{
    public class CountryCode
    {
        private CountryCode(string code, string name)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; }

        public string Code { get; }

        public static CountryCode Create(string code, string name) => new CountryCode(code, name);
    }
}