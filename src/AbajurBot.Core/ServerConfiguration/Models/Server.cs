namespace AbajurrBot.Core.ServerConfiguration.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Dictionary<string, Channel> Channels { get; set; }
    }
}
