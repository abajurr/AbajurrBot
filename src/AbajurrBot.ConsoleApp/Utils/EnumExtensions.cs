using DSharpPlus;
using DSharpPlus.Entities;

namespace AbajurrBot.ConsoleApp.Utils
{
    public static class EnumExtensions
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

        public static DiscordColor ToDiscordColor(this Core.Models.Color color)
        {
            return color switch
            {
                Core.Models.Color.Red => DiscordColor.Red,
                Core.Models.Color.Green => DiscordColor.Green,
                Core.Models.Color.Blue => DiscordColor.Blue,
                _ => DiscordColor.None,
            };
        }
    }
}
