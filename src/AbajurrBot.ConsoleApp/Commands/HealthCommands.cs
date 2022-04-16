using DSharpPlus.SlashCommands;

namespace AbajurrBot.ConsoleApp.Commands
{
    public class HealthCommands : ApplicationCommandModule
    {
        [SlashCommand("ping", "Sends a ping command to check bot health.")]
        public static async Task PingCommand(InteractionContext context)
        {
            try
            {
                await context.CreateResponseAsync("Pong!");
            }
            catch (Exception ex)
            {
                await context.CreateResponseAsync(ex.Message);
            }
        }
    }
}
