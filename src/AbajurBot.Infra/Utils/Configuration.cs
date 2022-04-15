using Microsoft.Extensions.Configuration;

namespace AbajurBot.Infra.Utils
{
    public class Configuration
    {
        private static readonly IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public static string AbajurToken =>
            Environment.GetEnvironmentVariable("ABAJURR_TOKEN", EnvironmentVariableTarget.Machine) ?? Config["ABAJURR_TOKEN"];

        public static string ServerConfigUrl => Config["SERVER_CONFIG_URL"];
    }
}
