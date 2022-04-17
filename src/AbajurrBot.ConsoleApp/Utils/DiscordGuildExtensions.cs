using AbajurrBot.Core.Models;
using DSharpPlus.Entities;

namespace AbajurrBot.ConsoleApp.Utils
{
    public static class DiscordGuildExtensions
    {
        public static async Task DeleteAllRolesAsync(this DiscordGuild guild)
        {
            foreach (var role in guild.Roles.Values)
            {
                if (role.IsManaged || role.Name == "@everyone")
                    continue;

                await role.DeleteAsync();
            }
        }

        public static async Task RestartGuildAsync(this DiscordGuild guild, Server server)
        {
            await guild.ClearGuildAsync();
            await guild.BuildGuildAsync(server);
        }

        public static async Task BuildGuildAsync(this DiscordGuild guild, Server server)
        {
            await guild.CreateChannelsAsync(server);
            await guild.CreateRolesAsync(server);
        }

        public static async Task ClearGuildAsync(this DiscordGuild guild)
        {
            await guild.DeleteAllChannelsAsync();
            await guild.DeleteAllRolesAsync();
        }

        public static async Task CreateRolesAsync(this DiscordGuild guild, Server server)
        {
            foreach (var role in server.Roles)
            {
                var createdRole = await guild.CreateRoleAsync(
                    name: role.Name,
                    color: role.Color.ToDiscordColor(),
                    hoist: role.Hoist);

                if (!role.Users.Any())
                    continue;

                foreach (var id in role.Users)
                {
                    var member = await guild.GetMemberAsync(id);

                    if (member == default)
                        continue;

                    await member.GrantRoleAsync(createdRole);
                }
            }
        }

        public static async Task CreateChannelsAsync(this DiscordGuild guild, Server server)
        {
            foreach (var categoryToCreate in server.Categories)
            {
                await guild.CreateCategoryWithChannels(server, categoryToCreate);
            }
        }

        public static async Task CreateCategoryWithChannels(this DiscordGuild guild, Server server, string category)
        {
            var createdCategory = await guild.CreateChannelCategoryAsync(category);
            var channelsToCreate = server.Channels.Where(c => c.Category == category);

            foreach (var channel in channelsToCreate)
            {
                await guild.CreateChannelAsync(channel, createdCategory);
            }
        }

        public static async Task CreateChannelAsync(this DiscordGuild guild, Channel channel, DiscordChannel category)
        {
            var channelType = channel.Type.ToDiscordChannelType();
            await guild.CreateChannelAsync(channel.Name, channelType, category);
        }
    }
}
