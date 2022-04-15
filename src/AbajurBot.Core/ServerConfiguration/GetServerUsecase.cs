using AbajurBot.Core.Clients;
using AbajurrBot.Core.ServerConfiguration.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AbajurBot.Core.ServerConfiguration
{
    public static class GetServerUsecase
    {
        public static async Task<Server> ExecuteAsync(IGithubClient githubClient, string configUrl)
        {
            var rawFile = await githubClient.GetRawFileAsync(configUrl);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var server = deserializer.Deserialize<Server>(rawFile);
            return server;
        }
    }
}
