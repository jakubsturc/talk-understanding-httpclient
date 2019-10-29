using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public static class HandlingRedirect
    {
        /// <summary>
        /// Showing how 302 works.
        /// </summary>
        public static async Task With302()
        {
            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            Console.WriteLine(await http.GetStringAsync("302"));
        }
        
        /// <summary>
        /// Showing how 301 works.
        /// </summary>
        public static async Task With301()
        {
            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            Console.WriteLine(await http.GetStringAsync("301"));
            Console.WriteLine(await http.GetStringAsync("301"));
        }

        /// <summary>
        /// Showing how to work with redirects manually.
        /// </summary>
        public static async Task DisableAutoRedirect()
        {
            var handler = new HttpClientHandler() { AllowAutoRedirect = false }; 
            var http = new HttpClient(handler) { BaseAddress = new Uri(Config.DebugServer) };
            var response = await http.GetAsync("301");
            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine($"Location: {response.Headers.Location}");
            
        }
    }
}
