using AbajurrBot.ConsoleApp.Utils;
using AbajurrBot.Core.Services.Interfaces;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class ServerCommands : ApplicationCommandModule
    {
        private readonly IServerServices _serverServices;
        private readonly DiscordWebhookBuilder _webhook;

        public ServerCommands(IServerServices serverServices, DiscordWebhookBuilder webhook)
        {
            _serverServices = serverServices;
            _webhook = webhook;
        }

        [SlashCommand("server", "Gets the current server configurations on Abajurr InfraDiscord")]
        public async Task GetServerCommand(InteractionContext context)
        {
            try
            {
                await context.DeferAsync();

                var url = Configuration.ServerConfigUrl;
                var server = await _serverServices.GetServerAsync(url);

                await context.EditResponseAsync(_webhook.WithContent($"{server}"));
            }
            catch (Exception ex)
            {
                await context.EditResponseAsync(_webhook.WithContent(ex.Message));
            }
        }
    }
}
