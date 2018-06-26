namespace DirectWeather.Api
{
    using System.Web.Http;

    using DirectWeather.Api.App_Start;

    using Newtonsoft.Json.Serialization;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            log4net.Config.XmlConfigurator.Configure();
            IoCSetup.WireEverything().ConnectToWebApiDependencyResovler();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}