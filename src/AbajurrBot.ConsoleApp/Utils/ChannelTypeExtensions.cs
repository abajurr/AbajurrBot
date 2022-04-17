using DSharpPlus;

namespace AbajurrBot.ConsoleApp.Utils
{
    public static class ChannelTypeExtensions
    {
        public static ChannelType ToDiscordChannelType(this Core.Models.ChannelType type)
        {
            return type switch
            {
                Core.Models.ChannelType.Text => ChannelType.Text,
                Core.Models.ChannelType.Voice => ChannelType.Voice,
                _ => ChannelType.Unknown,
            };
        }
    }
}
