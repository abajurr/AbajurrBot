using AbajurrBot.ConsoleApp.Handlers;
using AbajurrBot.ConsoleApp.Utils;
using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class ServerCommands : ApplicationCommandModule
    {
        private readonly ServerCommandsHandler _handler;

        public ServerCommands(ServerCommandsHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand(StringConstants.Server.GetServerCommand, StringConstants.Server.GetServerCommandDescription)]
        public async Task GetServerCommand(InteractionContext context)
        {
            var command = new GetServerCommandParams(context, Configuration.ServerConfigUrl);
            await _handler.Handle(command);
        }

        [SlashCommand(StringConstants.Server.ApplyCommand, StringConstants.Server.ApplyCommandDescription)]
        public async Task ApplyServerConfigCommand(InteractionContext context)
        {
            var command = new ApplyServerConfigCommandParams(context, Configuration.ServerConfigUrl);
            await _handler.Handle(command);
        }

        [SlashCommand("restart", "Delete all channels and create a channel called test")]
        public static async Task RestartGuildCommand(InteractionContext context)
        {
            await context.StartResponseAsync();
            await context.Guild.ClearGuildAsync();
            await context.Guild.CreateChannelAsync("test", DSharpPlus.ChannelType.Text);
        }
    }
}
