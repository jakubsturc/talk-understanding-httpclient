using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public static class UsingCookies
    {
        /// <summary>
        /// Showing how to read cookie from the  response.
        /// </summary>
        /// <returns></returns>
        public static async Task Read()
        {
            var handler = new HttpClientHandler();
            var http = new HttpClient(handler);
            http.BaseAddress = new Uri(Config.DebugServer);

            using var request = new HttpRequestMessage(HttpMethod.Get, "cookie");
            using var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Console.WriteLine($"Reading cookies from {http.BaseAddress}");
            var cookies = handler.CookieContainer.GetCookies(http.BaseAddress);
            foreach (Cookie cookie in cookies)
            {
                Console.WriteLine(new { cookie.Name, cookie.Value, cookie.TimeStamp});
            }
        }

        /// <summary>
        /// Showing how to add cookie to the request.
        /// </summary>
        public static async Task Send()
        {
            var handler = new HttpClientHandler()
            {
                UseCookies = true // not needed, default value
            };
            var container = handler.CookieContainer;
            var http = new HttpClient(handler);
            http.BaseAddress = new Uri(Config.DebugServer);

            // note: it's important to add host
            container.Add(new Cookie(name: "test", value: "*", path: "/", domain: http.BaseAddress.Host));

            using var request = new HttpRequestMessage(HttpMethod.Get, "cookie");
            using var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Console.WriteLine($"Reading cookies from {http.BaseAddress}");
            var cookies = container.GetCookies(http.BaseAddress);
            foreach (Cookie cookie in cookies)
            {
                Console.WriteLine(new { cookie.Name, cookie.Value, cookie.TimeStamp });
            }
        }
    }
}
