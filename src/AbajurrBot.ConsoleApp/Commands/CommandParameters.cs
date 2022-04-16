using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public record GetServerCommandParams(InteractionContext Context, string Url);
}
