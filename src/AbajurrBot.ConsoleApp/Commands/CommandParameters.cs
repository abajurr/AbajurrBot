using AbajurrBot.Core.Models;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public record GetServerCommandParams(InteractionContext Context, string Url);

    public record ApplyServerConfigCommandParams(InteractionContext Context, string Url);
}
