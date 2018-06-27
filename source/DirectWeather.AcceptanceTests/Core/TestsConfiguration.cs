namespace DirectWeather.AcceptanceTests.Core
{
    using System.Configuration;

    public static class TestsConfiguration
    {
        public static string Url => ConfigurationManager.AppSettings["Url"];

        public static string ReportsDirectory => ConfigurationManager.AppSettings["ReportsDirectory"];
    }
}