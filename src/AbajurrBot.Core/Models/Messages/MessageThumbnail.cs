namespace AbajurrBot.Core.Models.Messages
{
    public class MessageThumbnail
    {
        public int? Height { get; set; }
        public string Url { get; set; } = string.Empty;
        public int? Width { get; set; }

        public override string ToString() => Url;
    }
}
