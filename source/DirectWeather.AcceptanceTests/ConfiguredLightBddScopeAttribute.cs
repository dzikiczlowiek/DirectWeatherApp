namespace DirectWeather.AcceptanceTests
{
    using DirectWeather.AcceptanceTests.Core;

    using LightBDD.Core.Configuration;
    using LightBDD.Framework.Reporting.Configuration;
    using LightBDD.Framework.Reporting.Formatters;
    using LightBDD.XUnit2;

    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            configuration
                .ReportWritersConfiguration()
                .AddFileWriter<PlainTextReportFormatter>(TestsConfiguration.ReportsDirectory + "\\{TestDateTimeUtc:yyyy-MM-dd-HH_mm_ss}_FeaturesReport.txt");
        }
    }
}
