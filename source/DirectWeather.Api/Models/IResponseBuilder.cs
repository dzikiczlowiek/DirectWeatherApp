namespace DirectWeather.Api.Models
{
    using System.Web.Http;

    using DirectWeather.Infrastructure.Dtos;

    public interface IResponseBuilder
    {
        IHttpActionResult MapWeatherDataResponse(QueryResult<IWeatherInfo> queryResult);
    }
}