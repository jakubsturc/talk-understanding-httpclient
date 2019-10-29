using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JakubSturc.Demo.UnderstandingHttpClient.DebugServer
{
    [Route("")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("hello")]
        public async Task<string> Hello([FromQuery] int delay = 0)
        {
            await Task.Delay(delay);
            return "Hello World";
        }

        [HttpGet("download")]
        public IActionResult Download()
        {
            var loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var bytes = Encoding.ASCII.GetBytes(loremIpsum);
            var memory = new MemoryStream(bytes);
            return File(memory, contentType: "text/plain", fileDownloadName: "lorem.txt");
        }

        [HttpGet("302")]
        public IActionResult Redirect302()
        {
            return RedirectToAction(nameof(Hello));
        }

        [HttpGet("301")]
        public IActionResult Redirect301()
        {
            return RedirectToActionPermanent(nameof(Hello));
        }

        [HttpPost("post-form")]
        public string Post([FromForm] string param1, [FromForm]int param2)
        {
            return (param1, param2).ToString();
        }

        [HttpPost("post-json")]
        public string Post([FromBody] int[] numbers)
        {
            return string.Join(",", numbers);
        }

        [HttpPost("post-file")]
        public async Task<string> Post(IFormFile textfile)
        {
            using var stream = textfile.OpenReadStream();
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        [HttpGet("cookie")]
        public string Cookie()
        {
            if (Request.Cookies.ContainsKey("test"))
            {
                var value = Request.Cookies["test"];
                Response.Cookies.Append("test", value + "*");
                return "Cookie was updated";
            }
            else
            {
                Response.Cookies.Append("test", "*");
                return "Cookies was created";
            }
        }
    }
}
