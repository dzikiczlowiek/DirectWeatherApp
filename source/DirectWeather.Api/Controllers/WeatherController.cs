namespace DirectWeather.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;

    using Microsoft.Web.Http;

    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/weather")]
    public class WeatherController : ApiController
    {
        private readonly IQueryDispatcher queryDispatcher;

        private readonly ResponseBuilder responseBuilder;

        public WeatherController(ResponseBuilder responseBuilder, IQueryDispatcher queryDispatcher)
        {
            this.responseBuilder = responseBuilder;
            this.queryDispatcher = queryDispatcher;
        }

        [Route("{country}/{city}")]
        [EnableCors("*", "*", "GET")]
        public async Task<IHttpActionResult> GetWeather(string country, string city)
        {
            var query = GetWeatherDataQuery.Create(country, city, TemperatureScale.Celsius);
            var result = await queryDispatcher.ProcessAsync(query);
            var response = responseBuilder.MapWeatherDataResponse(result);
            return Ok(response);
        }
    }
}