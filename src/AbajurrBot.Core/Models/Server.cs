namespace AbajurrBot.Core.Models
{
    public class Server
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();
        public List<Channel> Channels { get; set; } = new();

        public bool Validate()
        {
            foreach(var channel in Channels)
            {
                ValidateChannel(channel);
            }

            return true;
        }

        private bool ValidateChannel(Channel channel)
        {
            var category = channel.Category;

            if (!Categories.Contains(category))
            {
                var channelCategories = string.Join(", ", Categories);

                throw new ArgumentException(
                    $"Channel {channel.Name} has unexisting category {category}. " +
                    $"Actual categories: {channelCategories}");
            }

            return true;
        }
    }
}
