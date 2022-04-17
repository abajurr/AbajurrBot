using AbajurrBot.Core.Models;
using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.Entities;

namespace AbajurrBot.ConsoleApp.Mappers
{
    public class EmbedMapper
    {
        public static List<DiscordEmbed> Map(Server server)
        {
            var rolesEmbed = Map(server.Roles);
            var channelsEmbed = Map(server.Channels);

            return new List<DiscordEmbed>
            {
                GetServerTitleEmbed,
                rolesEmbed,
                channelsEmbed,
            };
        }

        public static DiscordEmbed Map(List<Role> roles)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Roles"
            };

            foreach(var role in roles)
            {
                embed.AddField(role.ToString(), role.UserInfos);
            }

            return embed;
        }

        public static DiscordEmbed Map(List<Channel> channels)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Channels",
            };

            var grouppedChannels = channels.GroupBy(c => c.Category);

            foreach (var group in grouppedChannels)
            {
                var content = string.Join('\n', group.ToList());
                embed.AddField($"{group.Key}", content.ToString());
            }

            return embed;
        }

        private static DiscordEmbed GetServerTitleEmbed => new DiscordEmbedBuilder
        {
            Title = StringConstants.Server.GetServerResponseTitle,
            Description = StringConstants.Server.GetServerResponseDescription,
        };
    }
}
