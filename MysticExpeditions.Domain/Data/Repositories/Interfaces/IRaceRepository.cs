using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories.Interfaces
{
    public interface IRaceRepository : IRepository<Race>
    {
        Task<List<Race>> GetRacesAsync();
    }
}
