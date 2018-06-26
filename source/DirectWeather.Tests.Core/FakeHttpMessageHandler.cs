namespace DirectWeather.Tests.Core
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            LastRequest = request;
            LastResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(StringResponse) };
            return LastResponse;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }

        public string StringResponse { get; set; } = "TEST";

        public HttpRequestMessage LastRequest { get; private set; }

        public HttpResponseMessage LastResponse { get; private set; }
    }
}