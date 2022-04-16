namespace AbajurrBot.Core.Models.Messages
{
    public class MessageFooter
    {
        public string IconUrl { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public override string ToString() => Text;
    }
}
