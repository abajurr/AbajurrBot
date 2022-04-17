using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class HealthCommands : ApplicationCommandModule
    {
        [SlashCommand(Strings.Health.PingCommand, Strings.Health.PingCommandDescription)]
        public static async Task PingCommand(InteractionContext context)
        {
            try
            {
                await context.CreateResponseAsync(Strings.Health.PingResponse);
            }
            catch (Exception ex)
            {
                await context.CreateResponseAsync(ex.Message);
            }
        }
    }
}
