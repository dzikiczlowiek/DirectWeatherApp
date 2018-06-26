namespace DirectWeather.Infrastructure.Extensions
{
    using System;
    using System.Globalization;

    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            return string.IsNullOrEmpty(text)
                       ? string.Empty
                       : CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public static string[] SplitByEmptySpace(this string text)
        {
            return string.IsNullOrEmpty(text)
                       ? new string[0]
                       : text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}