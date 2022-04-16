using AbajurrBot.Core.Clients;
using AbajurrBot.Core.Models;
using AbajurrBot.Core.Services.Interfaces;
using YamlDotNet.Serialization;

namespace AbajurrBot.Core.Services
{
    public class ServerService : IServerService
    {
        private readonly IGithubClient _githubClient;
        private readonly IDeserializer _deserializer;

        public ServerService(IGithubClient githubClient, IDeserializer deserializer)
        {
            _githubClient = githubClient;
            _deserializer = deserializer;
        }

        public async Task<Server> GetServerAsync(string url)
        {
            var rawFile = await _githubClient.GetRawFileAsync(url);
            var server = _deserializer.Deserialize<Server>(rawFile);

            return server;
        }
    }
}
