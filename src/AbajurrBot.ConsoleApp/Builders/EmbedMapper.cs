using AbajurrBot.Core.Models;
using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.Entities;
using System.Text;

namespace AbajurrBot.ConsoleApp.Mappers
{
    public class EmbedMapper
    {
        public static DiscordEmbed Map(Server server)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = Strings.Server.MessageTitle,
                Description = Strings.Server.MessageDescription,
            };

            var grouppedChannels = server.Channels.Values.GroupBy(c => c.ChannelType);

            foreach (var group in grouppedChannels)
            {
                var channels = new StringBuilder();

                foreach(var channel in group)
                {
                    channels.AppendLine($"- {channel.Name}");
                }

                embed.AddField($"{group.Key} Channels", channels.ToString(), inline: true);
            }

            return embed;
        }
    }
}
