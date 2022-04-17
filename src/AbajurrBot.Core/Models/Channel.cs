namespace AbajurrBot.Core.Models
{
    public class Channel
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ChannelType Type { get; set; }

        public override string ToString() => $"- {Name} [{Type}]";
    }
}
