using MysticExpeditions.Domain.Data;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Data.Repositories.Interfaces
{
    public interface IGameSaveRepository : IRepository<GameSave>
    {
        Task<GameSave> GetByIdAsync(int gameSaveId);

        Task<IEnumerable<GameSave>> GetAllAsync();
        Task DeleteAsync(int gameSaveId);
    }
}
