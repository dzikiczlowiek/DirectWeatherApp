namespace DirectWeather.Source.OpenWeatherMap.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DirectWeather.Source.OpenWeatherMap.Dtos;

    public class CountryCodesSource : ICountryCodesSource
    {
        private readonly Lazy<IEnumerable<CountryCode>> countryCodes =
            new Lazy<IEnumerable<CountryCode>>(() => Load(Resources.country_codes));

        public CountryCode SearchByName(string term)
        {
            return countryCodes.Value.Where(x => x.Name.StartsWith(term, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(x => x.Name).FirstOrDefault();
        }

        private static IEnumerable<CountryCode> Load(string resource)
        {
            var source = new List<CountryCode>();
            using (var sr = new StringReader(resource))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var code = parts[1].ToUpper();
                    var name = parts[0].ToUpper();

                    source.Add(CountryCode.Create(code, name));
                }
            }

            return source;
        }
    }
}