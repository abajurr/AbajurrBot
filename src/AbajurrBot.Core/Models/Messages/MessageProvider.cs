namespace AbajurrBot.Core.Models.Messages
{
    public class MessageProvider
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
