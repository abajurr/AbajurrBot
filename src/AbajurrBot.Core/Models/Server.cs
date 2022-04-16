using System.Text;

namespace AbajurrBot.Core.Models
{
    public class Server
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public Dictionary<string, Channel> Channels { get; set; } = new();

        public string GetInfos()
        {
            var infos = new StringBuilder();
            var grouppedChannels = Channels.Values.GroupBy(c => c.ChannelType).ToList();

            infos.AppendLine($"- Image: {Icon}");

            foreach (var group in grouppedChannels)
            {
                infos.AppendLine($"- {group.Key} Channels:");

                foreach (var channel in group)
                {
                    infos.AppendLine($"  - {channel.Name}");
                }
            }

            return infos.ToString();
        }
    }
}
