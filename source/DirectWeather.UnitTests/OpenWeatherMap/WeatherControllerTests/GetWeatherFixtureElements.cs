namespace DirectWeather.UnitTests.OpenWeatherMap.WeatherControllerTests
{
    using System.Web.Http;

    using DirectWeather.Api.ActionResults;
    using DirectWeather.Api.Models;
    using DirectWeather.Infrastructure.Dtos;
    using DirectWeather.Infrastructure.QueryHandlers;
    using DirectWeather.Source.OpenWeatherMap.QueryHandlers;
    using DirectWeather.Tests.Core;

    using NSubstitute;

    public class GetWeatherFixtureElements : IFixtureElements
    {
        public GetWeatherFixtureElements()
        {
            QueryDispatcher.ProcessAsync(Arg.Do<GetWeatherDataQuery>(q => Query = q));
        }

        public IResponseBuilder ResponseBuilder { get; set; } = Substitute.For<IResponseBuilder>();

        public IQueryDispatcher QueryDispatcher { get; set; } = Substitute.For<IQueryDispatcher>();

        public IHttpActionResult Response { get; set; }

        public WeatherRequest Request { get; set; }

        public GetWeatherDataQuery Query { get; set; }

        public QueryResult<IWeatherInfo> QueryResult { get; set; }

        public ApiResponse<Weather> MappedResponse { get; set; }
    }
}