using AbajurrBot.Core.Utils.Constants;
using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class HealthCommands : ApplicationCommandModule
    {
        [SlashCommand(Strings.Health.Command, Strings.Health.CommandDescription)]
        public static async Task PingCommand(InteractionContext context)
        {
            try
            {
                await context.CreateResponseAsync(Strings.Health.CommandResponse);
            }
            catch (Exception ex)
            {
                await context.CreateResponseAsync(ex.Message);
            }
        }
    }
}
