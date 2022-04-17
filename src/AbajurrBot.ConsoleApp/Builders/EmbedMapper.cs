using AbajurrBot.Core.Models;
using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.Entities;

namespace AbajurrBot.ConsoleApp.Mappers
{
    public class EmbedMapper
    {
        public static List<DiscordEmbed> Map(Server server)
        {
            var channelsEmbed = Map(server.Channels);

            return new List<DiscordEmbed>
            {
                channelsEmbed,
            };
        }

        public static DiscordEmbed Map(List<Channel> channels)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = StringConstants.Server.GetServerResponseTitle,
                Description = StringConstants.Server.GetServerResponseDescription,
            };

            var grouppedChannels = channels.GroupBy(c => c.Category);

            foreach (var group in grouppedChannels)
            {
                var content = string.Join('\n', group.ToList());
                embed.AddField($"{group.Key}", content.ToString());
            }

            return embed;
        }
    }
}
