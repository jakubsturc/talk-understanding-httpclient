using System.Threading.Tasks;

namespace JakubSturc.Demo.UnderstandingHttpClient.ConsoleApp
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // await HelloWorld.Simple();
            // await PerformPostRequest.Form();
            await HandleDownload.LargeFile();
            // await Redirect.DisableAutoRedirect();
            // await Cookies.Read();
        }
    }
}