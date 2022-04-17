using AbajurrBot.ConsoleApp.Commands;
using AbajurrBot.ConsoleApp.Mappers;
using AbajurrBot.Core.Services.Interfaces;
using DSharpPlus;
using DSharpPlus.Entities;

namespace AbajurrBot.ConsoleApp.Handlers
{
    public class ServerCommandsHandler
    {
        private readonly IServerService _serverService;
        private readonly DiscordWebhookBuilder _webhook;

        public ServerCommandsHandler(IServerService serverService, DiscordWebhookBuilder webhook)
        {
            _serverService = serverService;
            _webhook = webhook;
        }

        public async Task Handle(GetServerCommandParams parameters)
        {
            var url = parameters.Url;
            var context = parameters.Context;

            await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            try
            {
                var server = await _serverService.GetServerAsync(url);
                var embeds = EmbedMapper.Map(server);
                await context.EditResponseAsync(_webhook.AddEmbeds(embeds));
            }
            catch (Exception ex)
            {
                await context.EditResponseAsync(_webhook.WithContent(ex.Message));
            }
        }
    }
}
