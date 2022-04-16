namespace AbajurrBot.Core.Models.Messages
{
    public class MessageVideo
    {
        public int? Heigth { get; set; }
        public string Url { get; set; } = string.Empty;
        public int? Width { get; set; }

        public override string ToString() => Url;
    }
}
