using AbajurrBot.Core.Models;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbajurrBot.Infra.Services.Interfaces
{
    public interface IDiscordService
    {
        Task CreateRolesAsync(Server server, DiscordGuild guild);
        Task CreateChannelsAsync(Server server, DiscordGuild guild);
        Task CreateCategoryWithChannels(DiscordGuild guild, Server server, string category);
        Task CreateChannelAsync(Channel channel, DiscordGuild guild, DiscordChannel category);
    }
}
