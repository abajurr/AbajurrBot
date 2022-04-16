using AbajurrBot.Core.Clients;

namespace AbajurrBot.Infra.Clients
{
    public class GithubClient : IGithubClient
    {
        private readonly HttpClient _httpClient;

        public GithubClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRawFileAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
