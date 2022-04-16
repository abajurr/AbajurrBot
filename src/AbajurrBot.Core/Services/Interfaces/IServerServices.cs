using AbajurrBot.Core.Models;

namespace AbajurrBot.Core.Services.Interfaces
{
    public interface IServerServices
    {
        Task<Server> GetServerAsync(string url);
    }
}
