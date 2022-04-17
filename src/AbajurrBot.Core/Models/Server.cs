using AbajurrBot.Core.Exceptions;

namespace AbajurrBot.Core.Models
{
    public class Server
    {
        public Server()
        {
            Validate();
        }

        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public List<Channel> Channels { get; set; } = new();

        private bool Validate()
        {
            foreach (var channel in Channels)
            {
                ValidateChannel(channel);
            }

            return true;
        }

        private bool ValidateChannel(Channel channel)
        {
            if (!Categories.Contains(channel.Category))
                throw new CategoryNotFoundException(this, channel);

            return true;
        }
    }
}
