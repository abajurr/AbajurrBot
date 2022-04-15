using AbajurBot.Infra.Clients;
using AbajurBot.Infra.Utils;
using DSharpPlus;
using AbajurBot.Core.ServerConfiguration;

static async Task MainAsync()
{
    var discord = new DiscordClient(new DiscordConfiguration()
    {
        Token = Configuration.AbajurToken,
        TokenType = TokenType.Bot
    });

    discord.MessageCreated += async (s, e) =>
    {
        if (e.Message.Content.ToLower() == "ping")
            await e.Message.RespondAsync("pong!");

        if(e.Message.Content.ToLower() == "config")
        {
            var httpClient = new HttpClient();
            var githubClient = new GithubClient(httpClient);

            var server = await GetServerUsecase.ExecuteAsync(githubClient, Configuration.ServerConfigUrl);

            await e.Message.RespondAsync(server.Icon);
        }
    };

    await discord.ConnectAsync();
    await Task.Delay(-1);
}

MainAsync().GetAwaiter().GetResult();
