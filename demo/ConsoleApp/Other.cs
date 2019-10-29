using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public static class Other
    {
        /// <summary>
        /// Showing:
        ///  * Automatic decompression
        ///  * Disable certification validation
        ///  * Custom headers
        /// </summary>
        public static async Task Example()
        {
            var handler = new HttpClientHandler() 
            {
                // for multiplatform code check SupportsAutomaticDecompression first
                AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.Deflate,
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var http = new HttpClient(handler)
            {
                BaseAddress = new Uri(Config.DebugServerSecure)
            };

            http.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-US,en;q=0.5");
            http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:70.0) Gecko/20100101 Firefox/70.0");

            Console.WriteLine(await http.GetStringAsync("debug"));
        }
    }
}
