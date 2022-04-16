namespace AbajurrBot.Core.Models.Messages
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
        public MessageAuthor? Author { get; set; }
        public MessageColor? Color { get; set; }
        public List<MessageField>? Fields { get; set; }
        public MessageFooter? Footer { get; set; }
        public MessageImage? Image { get; set; }
        public MessageProvider? Provider { get; set; }
        public MessageVideo? Video { get; set; }

        public override string ToString() => Title;
    }
}
