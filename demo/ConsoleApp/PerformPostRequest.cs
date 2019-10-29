using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    public class PerformPostRequest
    {
        /// <summary>
        /// Showing how to post form
        /// </summary>
        public static async Task Form()
        {
            var content = new StringContent("param1=test&param2=42", Encoding.UTF8, "application/x-www-form-urlencoded");
            
            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            var response = await http.PostAsync("post-form", content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Showing how to post JSON file
        /// </summary>
        public static async Task Json()
        {
            var json = JsonSerializer.Serialize(new int[] { 4, 8, 15, 16, 23, 42 });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            var response = await http.PostAsync("post-json", content);
            response.EnsureSuccessStatusCode();
            
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Saving some bytes using Utf8 bytes instead String.
        /// </summary>
        public static async Task JsonFancy()
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(new int[] { 4, 8, 15, 16, 23, 43 });
            using var memory = new MemoryStream(bytes);
            using var content = new StreamContent(memory);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            var response = await http.PostAsync("post-json", content);
            response.EnsureSuccessStatusCode();
            
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Showing how to upload file using MultipartForm
        /// </summary>
        public static async Task File()
        {
            var bytes = Encoding.UTF8.GetBytes("Hello .NET Bratislava Meetup");
            using var memory = new MemoryStream(bytes);
            using var content = new StreamContent(memory);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/html");

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(content, name: "textfile", fileName: "text.txt");

            var http = new HttpClient() { BaseAddress = new Uri(Config.DebugServer) };
            var response = await http.PostAsync("post-file", multipartContent);
            response.EnsureSuccessStatusCode();

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
