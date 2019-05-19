using System.Net.Http;
using System.Net.Http.Headers;

namespace TheGuardianApi.ApiConsumer.Helpers
{
    public static class ApiHelper
    {
        public static HttpClient HttpClient { get; set; }

        public static void InitializeClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void DisposeClient()
        {
            HttpClient.Dispose();
        }
    }
}
