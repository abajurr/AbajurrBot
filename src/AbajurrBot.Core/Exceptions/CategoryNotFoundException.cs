using AbajurrBot.Core.Models;

namespace AbajurrBot.Core.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(Server server, Channel channel)
        {
            Server = server;
            Channel = channel;
        }

        public Server Server { get; set; }
        public Channel Channel { get; set; }

        public override string Message =>
            $"Channel {Channel.Name} has unexisting category {Channel.Category}. " +
            $"Actual categories: {string.Join(", ", Server.Categories)}";
    }
}
