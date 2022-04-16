using YamlDotNet.Serialization;

namespace AbajurrBot.Core.Models
{
    public class Channel
    {
        public string Name { get; set; } = string.Empty;

        [YamlMember(Alias = "type")]
        public ChannelType ChannelType { get; set; }
    }
}
