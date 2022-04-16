using AbajurrBot.Core.Models;

namespace AbajurrBot.Core.Services.Interfaces
{
    public interface IServerService
    {
        Task<Server> GetServerAsync(string url);
    }
}
