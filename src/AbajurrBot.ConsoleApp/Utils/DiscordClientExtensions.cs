using DSharpPlus;
using DSharpPlus.SlashCommands;
using System.Reflection;

namespace AbajurrBot.ConsoleApp.Utils
{
    public static class DiscordClientExtensions
    {
        public static void ConfigureSlashCommands(this DiscordClient client, IServiceProvider serviceProvider)
        {
            var config = new SlashCommandsConfiguration { Services = serviceProvider };
            var slashCommands = client.UseSlashCommands(config);

            slashCommands.RegisterCommands(Assembly.GetExecutingAssembly(), Configuration.GuildId);
        }
    }
}
