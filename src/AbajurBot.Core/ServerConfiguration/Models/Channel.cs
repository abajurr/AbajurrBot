using YamlDotNet.Serialization;

namespace AbajurrBot.Core.ServerConfiguration.Models
{
    public class Channel
    {
        public string Name { get; set; }

        [YamlMember(Alias = "type")]
        public ChannelType ChannelType { get; set; }
    }
}
