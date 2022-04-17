namespace AbajurrBot.Core.Models
{
    public class Role
    {
        public string Name { get; set; } = string.Empty;
        public Color Color { get; set; }
        public bool? Hoist { get; set; }
        public List<ulong> Users { get; set; } = new();

        public override string ToString() => $"{Name} [{Color}]";
        public string UserInfos =>
            Users.Any() ?
            string.Join('\n', Users.Select(u => $"- <@{u}>")) :
            "- No users";
    }
}
