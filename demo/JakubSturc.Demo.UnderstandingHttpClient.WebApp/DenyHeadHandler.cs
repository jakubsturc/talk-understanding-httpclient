using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.WebApp
{
    public class DenyHeadHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Head)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Sorry, head is not allowed here.")
                };
            }

            return await base.SendAsync(request, cancellationToken); ;
        }
    }
}
