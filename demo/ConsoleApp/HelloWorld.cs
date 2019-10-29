using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public static class HelloWorld
    {
        /// <summary>
        /// The simple version
        /// </summary>
        public static async Task Simple()
        {
            var http = new HttpClient();
            var response = await http.GetStringAsync(Config.DebugServer + "hello"); 
            Console.WriteLine(response);
            
            // no need for .ConfigureAwait(false) in .NET Core 3.0
        }


        /// <summary>
        /// Showing BaseAddress, EnsureSuccessStatusCode, HttpResponseMessage
        /// </summary>
        public static async Task Intermediate()
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri(Config.DebugServer);
            var response = await http.GetAsync("hello");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        /// <summary>
        /// Showing HttpRequestMessage & SendAsync method
        /// </summary>
        public static async Task Fancy()
        {
            var http = new HttpClient();
            http.BaseAddress = new Uri(Config.DebugServer);
            using var request = new HttpRequestMessage(HttpMethod.Get, "hello");
            using var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}