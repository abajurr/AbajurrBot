namespace AbajurrBot.Core.Clients
{
    public interface IGithubClient
    {
        Task<string> GetRawFileAsync(string url);
    }
}
