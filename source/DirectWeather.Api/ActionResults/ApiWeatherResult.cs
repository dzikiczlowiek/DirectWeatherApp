namespace DirectWeather.Api.ActionResults
{
    // public class ApiResult : IHttpActionResult
    // {
    // private readonly ApiResponse responseData;

    // public ApiResult(Weather data, long timestamp)
    // {
    // this.responseData = ApiResponse<Weather>.Success(data, timestamp);
    // }

    // public ApiResult(string message, long timestamp)
    // {
    // responseData = ApiResponse.Error(message, timestamp);
    // }

    // public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    // {
    // var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
    // response.Content = new ObjectContent(typeof(ApiResponse), responseData, new JsonMediaTypeFormatter());
    // return Task.FromResult(response);
    // }
    // }
}