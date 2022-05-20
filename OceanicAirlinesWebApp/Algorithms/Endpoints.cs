using OceanicAirlinesWebApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace OceanicAirlinesWebApp.Algorithms
{
    public static class Endpoints
    {
        private const string EIT_ENDPOINT = "https://wa-eit-dk1.azurewebsites.net/api/route";
        private const string TL_ENDPOINT = " https://wa-tl-dk1.azurewebsites.net/api/segments";

        private static HttpClient client = new HttpClient();

        public static async Task<ResultDTO> FetchResultFromEIT(RequestDTO request)
        {
            request.From = request.From.ToLower();
            request.To = request.To.ToLower();
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(EIT_ENDPOINT),
                Content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(message).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ResultDTO>(responseBody);
        }

        public static async Task<ResultDTO> FetchResultFromTL(RequestDTO request)
        {
            request.From = request.From.ToLower();
            request.To = request.To.ToLower();
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(TL_ENDPOINT),
                Content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(message).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ResultDTO>(responseBody);
        }
    }
}
