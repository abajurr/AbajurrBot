namespace AbajurBot.Core.Clients
{
    public interface IGithubClient
    {
        Task<string> GetRawFileAsync(string url);
    }
}
