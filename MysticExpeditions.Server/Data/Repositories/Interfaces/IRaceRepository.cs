using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories.Interfaces
{
    public interface IRaceRepository : IRepository<Race>
    {
        Task<List<Race>> GetRacesAsync();
    }
}