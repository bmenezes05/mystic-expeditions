using MysticExpeditions.Server.Models;

namespace MysticExpeditions.Server.Data.Repositories
{
    public interface IGameSaveRepository : IRepository<GameSave>
    {
        Task<GameSave> GetByIdAsync(int gameSaveId);

        Task<IEnumerable<GameSave>> GetAllAsync();        
        Task DeleteAsync(int gameSaveId);
    }
}