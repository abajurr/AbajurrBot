using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class HealthCommands : ApplicationCommandModule
    {
        [SlashCommand(StringConstants.Health.PingCommand, StringConstants.Health.PingCommandDescription)]
        public static async Task PingCommand(InteractionContext context)
        {
            try
            {
                await context.CreateResponseAsync(StringConstants.Health.PingResponse);
            }
            catch (Exception ex)
            {
                await context.CreateResponseAsync(ex.Message);
            }
        }
    }
}
