using AbajurrBot.Core.Models;
using AbajurrBot.Core.Services.Interfaces;
using YamlDotNet.Serialization;

namespace AbajurrBot.Core.Services
{
    public class ServerService : IServerService
    {
        private readonly HttpClient _httpClient;
        private readonly IDeserializer _deserializer;

        public ServerService(HttpClient httpClient, IDeserializer deserializer)
        {
            _httpClient = httpClient;
            _deserializer = deserializer;
        }

        public async Task<Server> GetServerAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var rawFile = await response.Content.ReadAsStringAsync();
            var server = _deserializer.Deserialize<Server>(rawFile);

            return server;
        }
    }
}
