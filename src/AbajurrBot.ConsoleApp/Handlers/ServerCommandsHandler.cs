using AbajurrBot.ConsoleApp.Commands;
using AbajurrBot.ConsoleApp.Mappers;
using AbajurrBot.ConsoleApp.Utils;
using AbajurrBot.Core.Models;
using AbajurrBot.Core.Services.Interfaces;
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
            var context = parameters.Context;
            await context.StartResponseAsync();

            try
            {
                var url = parameters.Url;
                var server = await _serverService.GetServerAsync(url);
                var embeds = EmbedMapper.Map(server);

                await context.EditResponseAsync(_webhook.AddEmbeds(embeds));
            }
            catch (Exception ex)
            {
                await context.EditResponseAsync(_webhook.WithContent(ex.Message));
            }
        }

        public async Task Handle(ApplyServerConfigCommandParams parameters)
        {
            var context = parameters.Context;
            await context.StartResponseAsync();

            try
            {
                var server = await _serverService.GetServerAsync(parameters.Url);
                var guild = context.Guild;

                await guild.RestartGuildAsync(server);
            }
            catch (Exception ex)
            {
                await context.EditResponseAsync(_webhook.WithContent(ex.Message));
            }
        }
    }
}
