namespace AbajurrBot.Core.Models.Messages
{
    public class MessageAuthor
    {
        public string Name { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
