using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherClient.Dao.Interfaces;

namespace WeatherClient.Dao
{
    class HttpClient : IHttpClient
    {
        private readonly string mainPageAddress = "http://localhost:5000";
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T> Get<T>(string address)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{mainPageAddress}/{address}");

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return await JsonSerializer.DeserializeAsync<T>(contentStream, options);
            }

            return default(T);
        }
    }
}
