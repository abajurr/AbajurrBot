using YamlDotNet.Serialization;

namespace AbajurrBot.Core.Models
{
    public class Channel
    {
        public string Name { get; set; }

        [YamlMember(Alias = "type")]
        public ChannelType ChannelType { get; set; }

        public override string ToString() => $"{Name} ({ChannelType})";
    }
}
