namespace AbajurrBot.Core.Models.Messages
{
    public class MessageField
    {
        public bool Inline { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public override string ToString() => Name;
    }
}
