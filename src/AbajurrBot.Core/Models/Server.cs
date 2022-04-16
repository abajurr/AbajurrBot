using AbajurrBot.Core.Utils;

namespace AbajurrBot.Core.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Dictionary<string, Channel> Channels { get; set; }

        public override string ToString()
        {
            return $"Nome: {Name}\nImagem: {Icon}\nCanais: {Channels.AsString()}";
        }
    }
}
