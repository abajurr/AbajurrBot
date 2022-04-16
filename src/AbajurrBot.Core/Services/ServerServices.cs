using AbajurrBot.Core.Clients;
using AbajurrBot.Core.Services.Interfaces;
using AbajurrBot.Core.Models;
using YamlDotNet.Serialization;

namespace AbajurrBot.Core.Services
{
    public class ServerServices : IServerServices
    {
        private readonly IGithubClient _githubClient;
        private readonly IDeserializer _deserializer;

        public ServerServices(IGithubClient githubClient, IDeserializer deserializer)
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
