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

                await guild.DeleteAllChannelsAsync();
                await CreateChannelsAsync(server, guild);
            }
            catch (Exception ex)
            {
                await context.EditResponseAsync(_webhook.WithContent(ex.Message));
            }
        }

        private static async Task CreateChannelsAsync(Server server, DiscordGuild guild)
        {
            foreach (var categoryToCreate in server.Categories)
            {
                await CreateCategoryWithChannels(guild, server, categoryToCreate);
            }
        }

        private static async Task CreateCategoryWithChannels(DiscordGuild guild, Server server, string category)
        {
            var createdCategory = await guild.CreateChannelCategoryAsync(category);
            var channelsToCreate = server.Channels.Where(c => c.Category == category);

            foreach (var channel in channelsToCreate)
            {
                await CreateChannelAsync(channel, guild, createdCategory);
            }
        }

        private static async Task CreateChannelAsync(Channel channel, DiscordGuild guild, DiscordChannel category)
        {
            var channelType = channel.Type.ToDiscordChannelType();
            await guild.CreateChannelAsync(channel.Name, channelType, category);
        }
    }
}
