using AbajurrBot.ConsoleApp.Utils;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;

namespace AbajurrBot.ConsoleApp
{
    public static class Program
    {
        public static void Main() => MainAsync().GetAwaiter().GetResult();

        public static async Task MainAsync()
        {
            var client = new DiscordClient(Configuration.DiscordConfig);
            var services = new ServiceCollection().ConfigureAbajurrServices().BuildServiceProvider();

            client.ConfigureSlashCommands(services);

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
