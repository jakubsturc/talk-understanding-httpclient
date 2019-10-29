using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace JakubSturc.Demo.UnderstandingHttpClient.WebApp
{
    [Route("")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly TypedHttpClient _typed;

        public Controller(IHttpClientFactory clientFactory, TypedHttpClient typed)
        {
            _clientFactory = clientFactory;
            _typed = typed;
        }

        [Route("")]
        public string Index()
        {
            // basic usage
            var client = _clientFactory.CreateClient();

            // named client
            var named = _clientFactory.CreateClient("super+");
           
            return "OK";
        }
    }
}
