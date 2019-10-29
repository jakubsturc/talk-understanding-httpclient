using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.WebApp
{
    public class TypedHttpClient
    {
        private readonly HttpClient _http;

        public TypedHttpClient(HttpClient http)
        {
            http.BaseAddress = new Uri("http://localhost:5000");
            http.DefaultRequestHeaders.UserAgent.ParseAdd("Typed Agent");
            _http = http;
        }

        public async Task<string> Hello()
        {
            return await _http.GetStringAsync("hello");
        }

        public async Task<bool> Send(int[] data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("post-json", content);
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
