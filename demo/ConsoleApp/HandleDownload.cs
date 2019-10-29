using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public static class HandleDownload
    {
        /// <summary>
        /// Showing HttpCompletionOption.ResponseHeadersRead and how to stream content.
        /// </summary>
        /// <returns></returns>
        public static async Task LargeFile()
        {
            var http = new HttpClient() 
            {
                Timeout = Timeout.InfiniteTimeSpan,         // rather don't use in production
                BaseAddress = new Uri(Config.DebugServer) 
            };

            using var response = await http.GetAsync("download", HttpCompletionOption.ResponseHeadersRead);
            using var content = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(content, Encoding.ASCII);

            Console.WriteLine(await reader.ReadToEndAsync());
        }
    }
}
