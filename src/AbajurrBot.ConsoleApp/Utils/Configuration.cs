using DSharpPlus;
using Microsoft.Extensions.Configuration;

namespace AbajurrBot.ConsoleApp.Utils
{
    public class Configuration
    {
        private static readonly IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        private static string AbajurrToken =>
            Environment.GetEnvironmentVariable("ABAJURR_TOKEN", EnvironmentVariableTarget.Machine) ??
            Config["ABAJURR_TOKEN"];

        public static string ServerConfigUrl =>
            Environment.GetEnvironmentVariable("SERVER_CONFIG_URL", EnvironmentVariableTarget.Machine) ??
            Config["SERVER_CONFIG_URL"];

        public static ulong GuildId => 964541011042926652;

        public static DiscordConfiguration DiscordConfig => new()
        {
            Token = AbajurrToken,
            TokenType = TokenType.Bot
        };
    }
}
