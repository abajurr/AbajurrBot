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

        [SlashCommand(Strings.Server.Command, Strings.Server.CommandDescription)]
        public async Task GetServerCommand(InteractionContext context)
        {
            var command = new GetServerCommandParams(context, Configuration.ServerConfigUrl);
            await _handler.Handle(command);
        }
    }
}
